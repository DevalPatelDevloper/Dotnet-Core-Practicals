using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_15.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
		private readonly ILogger _logger;
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[HttpGet]
		public IActionResult Get()
		{
			_logger.LogInformation("Homepage was requested");
			try
			{
				throw new Exception("Oops! An Exception is going on!");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.ToString());
			}
			return Ok("Hello World APi");
		}
	}
}
