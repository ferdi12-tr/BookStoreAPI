using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
			_logger = logger;
        }

		[HttpGet]
		public IActionResult Get()
		{
			_logger.LogInfo("Info message from custom logger service");
			_logger.LogDebug("Debug message from custom logger service");
			_logger.LogWarn("Warning message from custom logger service");
			_logger.LogError("Error message from custom logger service");
			return Ok();
		}
    }
}
