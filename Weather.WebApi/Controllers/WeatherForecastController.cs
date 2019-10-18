using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.WebApi.Dtos;
using Weather.WebApi.Request;

namespace Weather.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async static void Get()
        {   
             var teste =  RequestApi.RequisitionGetAsync("123");

           // return await teste;
        }
    }
}
