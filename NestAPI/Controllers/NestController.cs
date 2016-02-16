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
        [HttpPost]
        public string SetTemperature(dynamic slots)
        {
            try
            {

                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();
                thermostat.target_temperature_f = slots.Temperature.value;

                return string.Format("Temperature has been changed to {0}.", thermostat.target_temperature_f);
            }
            catch (Exception ex)
            {
                return string.Format("Error occured. Unable to change the temperature. Error message... {0}", ex.Message);
            }
        }

        [HttpGet]
        public string GetCurrentTemperature()
        {
            try
            {
                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();

                return string.Format("Current temperature is {0}.", thermostat.ambient_temperature_f);
            }
            catch (Exception ex)
            {
                return string.Format("Error occured. Unable to read the current temperature. Error message... {0}", ex.Message);
            }
        }        
        
        [HttpGet]
        public string GetTargetTemperature()
        {
            try
            {
                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();

                return string.Format("Target temperature is {0}.", thermostat.target_temperature_f);
            }
            catch (Exception ex)
            {
                return string.Format("Error occured. Unable to read the target temperature. Error message... {0}", ex.Message);
            }
        }
        
    }
}
