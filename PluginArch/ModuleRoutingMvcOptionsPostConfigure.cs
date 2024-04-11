using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;

using Shared;

public class ModuleRoutingMvcOptionsPostConfigure : IPostConfigureOptions<MvcOptions>
{
    private readonly IEnumerable<Plugin> _modules;

    public ModuleRoutingMvcOptionsPostConfigure(IEnumerable<Plugin> modules) => _modules = modules;

    public void PostConfigure(string name, MvcOptions options)
    {
        options.Conventions.Add(new ModuleRoutingConvention(_modules));
    }
}



