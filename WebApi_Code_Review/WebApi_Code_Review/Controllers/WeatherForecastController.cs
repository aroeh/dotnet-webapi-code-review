using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using WebApi_Code_Review.Models;

namespace WebApi_Code_Review.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private static readonly Person[] samplePeople = new[]
        {
            new Person
            {
                FirstName = "Sample",
                lastName = "Person",
                Middlename = string.Empty
            },
            new Person
            {
                FirstName = "Sample2",
                lastName = "Person2",
                Middlename = null
            },
            new Person
            {
                FirstName = "Sample3",
                lastName = "Person3",
                Middlename = "C"
            },
            new Person
            {
                FirstName = "Sample4",
                lastName = "Person4",
                Middlename = ""
            }
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            try
            {
                return samplePeople;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public Person GetPerson(string id)
        {
            try
            {
                var personId = 0;
                int.TryParse(id, out personId);

                var person = samplePeople[personId];

                if(personId == 0)
                {
                    person = null;
                }

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}