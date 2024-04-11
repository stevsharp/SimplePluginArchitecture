
using ModuleTest.Service;

namespace ModuleTest
{
    public class Startup : Shared.IStartup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            // Do the Registration 
            services.AddScoped<IHelloWorldService, HelloWorldService>();
     
        
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
