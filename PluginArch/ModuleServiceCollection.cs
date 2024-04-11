using Microsoft.AspNetCore.Mvc.ApplicationParts;

using Shared;

namespace PluginArch;

    public static class ModuleServiceCollection
    {
        public static IServiceCollection AddModule<TStartup>(this IServiceCollection services, string routePrefix)
            where TStartup : Shared.IStartup, new()
        {
            // Register assembly in MVC so it can find controllers of the module
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                manager.ApplicationParts.Add(new AssemblyPart(typeof(TStartup).Assembly)));

            var startup = new TStartup();
            startup.ConfigureServices(services);

            services.AddSingleton(new Plugin(routePrefix, startup));

            return services;
        }
    }

