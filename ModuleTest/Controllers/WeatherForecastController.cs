using Microsoft.AspNetCore.Mvc;

using ModuleTest.Service;

namespace ModuleTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        protected IHelloWorldService _helloWorldService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHelloWorldService helloWorldService)
        {
            _logger = logger;
            _helloWorldService = helloWorldService;
        }

        [HttpGet(Name = "Hello")]

        public string Hello()
        {
            return _helloWorldService.Hello();
        }
    }
}
