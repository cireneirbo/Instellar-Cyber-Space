using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instellar_Cyber_Space.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class MarsForecastController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<MarsForecastController> _logger;

		public MarsForecastController(ILogger<MarsForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<MarsForecast> Get()
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new MarsForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
