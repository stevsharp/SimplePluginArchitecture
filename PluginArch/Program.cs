using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using PluginArch;

using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().ConfigureApplicationPartManager(manager =>
{
    // Clear all auto detected controllers.
    manager.ApplicationParts.Clear();

    // Add feature provider to allow "internal" controller
    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
});

builder.Services.AddTransient<IPostConfigureOptions<MvcOptions>, ModuleRoutingMvcOptionsPostConfigure>();

builder.Services.AddModule<ModuleTest.Startup>("module-1");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.MapControllers();

// Adds endpoints defined in modules
var modules = app.Services.GetRequiredService<IEnumerable<Plugin>>();


foreach (var module in modules)
{
    app.Map($"/{module.RoutePrefix}", builder =>
    {
        builder.UseRouting();
        module.Startup.Configure(builder);
    });
}


app.Run();
