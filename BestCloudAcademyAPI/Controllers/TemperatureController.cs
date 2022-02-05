using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BestCloudAcademyAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {

        [HttpGet("")]
        public Person Get()
        {
            Person person1 = new Person { FirstName = "Görkem Etem", LastName = "Irmak" };
            return person1;
        }

        [HttpGet("temperature")]
        public Weather Get(string city)
        {
            string api = "088311902dbed3f3e2094d195a47cec6";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument weather = XDocument.Load(connection);
            var temp = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            Weather weather1 = new Weather();
            weather1.Temperature = temp;
            return weather1;
        }

    }
}
