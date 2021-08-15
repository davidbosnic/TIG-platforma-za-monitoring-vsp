using API_Diamond_Gold_InflationRate_Crypto.Broker;
using API_Diamond_Gold_InflationRate_Crypto.Services;
using DocumentFormat.OpenXml.Packaging;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Diamond_Gold_InflationRate_Crypto.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ITelegrafService _telegrafservice;

        public HomeController()
        {
            _telegrafservice = new TelegrafService();
        }

        [HttpPost("{measurement}")]
        public IActionResult WriteDGICData([Required, FromBody] DGIC data, string measurement)
        {
            if(_telegrafservice!=null)
            {
                try
                {
                    _telegrafservice.Write(data, measurement);
                    return Ok();
                }
                catch (Exception e) 
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost("{data}")]
        public IActionResult WriteStringData(string data)
        {
            if (_telegrafservice != null)
            {
                try
                {
                    _telegrafservice.Write(data);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult WriteDataPoint([Required, FromBody] PointData data)
        {
            if (_telegrafservice != null)
            {
                try
                {
                    _telegrafservice.Write(data);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
     

        [HttpPost("{filepath}/{measurement}")]
        public IActionResult WriteCSVFile(string filepath, string measurement)
        {
            if (_telegrafservice != null)
            {
                try
                {
                    _telegrafservice.WriteCSVFile(filepath, measurement);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPost("{measurement}")]
        public IActionResult WriteCSVFile(IFormFile file, string measurement)
        {
            if (_telegrafservice != null)
            {
                try
                {
                    _telegrafservice.WriteCSVFile(file, measurement);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
   
    }
}
