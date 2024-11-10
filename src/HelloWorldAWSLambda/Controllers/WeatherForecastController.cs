using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldAWSLambda
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController: ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            var summaries = new[]
            {
                "Freezing-Wod", "Bracing-Wod"
            };


            var forecast =  Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();

            return Ok(forecast);
        }
    }
}