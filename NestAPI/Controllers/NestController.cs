using NestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NestAPI.Controllers
{
    public class NestController : BaseController
    {
        [HttpGet]
        public dynamic SetTemperature(int temp)
        {
            try
            {
                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();
                thermostat.target_temperature_f = temp;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
