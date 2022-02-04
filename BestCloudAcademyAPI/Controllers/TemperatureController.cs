using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestCloudAcademyAPI.Controllers
{
    [Route("")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {

        Person person1 = new Person { FirstName = "Görkem Etem", LastName = "Irmak" };

        [HttpGet("")]
        public Person Get()
        {
            return person1;
        }

        [HttpGet("temperature")]
        public string Get(string city)
        {
            return "DENEME";
        }
    }
}
