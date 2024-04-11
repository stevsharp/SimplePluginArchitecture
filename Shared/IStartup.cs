using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace Shared;

    public interface IStartup
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }

public record Plugin
{
    public string RoutePrefix { get; }

    public Shared.IStartup Startup { get; }

    public Assembly Assembly => Startup.GetType().Assembly;

    public Plugin(string routePrefix, Shared.IStartup startup)
    {
        RoutePrefix = routePrefix;
        Startup = startup;
    }
}

