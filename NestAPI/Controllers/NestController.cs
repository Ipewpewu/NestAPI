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
        //[HttpGet]
        //public dynamic SetTemperature(int temp)
        //{
        //    try
        //    {
        //        var nest = new Nest();
        //        var thermostats = nest.devices.thermostats;
        //        var thermostat = thermostats.FirstOrDefault();
        //        thermostat.target_temperature_f = temp;

        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        return false;
        //    }
        //}
        [HttpPost]
        public string SetTemperature(dynamic slots)
        {
            try
            {
                                
                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();
                thermostat.target_temperature_f = slots.Temperature.value;

                //thermostat.target_temperature_f = float.Parse(((string)slots.Temperature.value).Replace("\"", ""));

                return string.Format("Temperature has been changed to {0}.", thermostat.target_temperature_f);
            }
            catch (Exception ex)
            {
                return string.Format("Error occured. Unable to change the temperature. Error message... {0}", ex.Message);
            }
        }
    }
}
