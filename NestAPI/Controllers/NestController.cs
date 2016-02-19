using NestAPI.Models;
using NestAPI.Models.Enums;
using NestAPI.Models.Enums.Shared;
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

        [HttpPost]
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
        
        [HttpPost]
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
        [HttpPost]
        public string SetHvacMode(dynamic slots)
        {
            try
            {
                var nest = new Nest();
                var thermostats = nest.devices.thermostats;
                var thermostat = thermostats.FirstOrDefault();                

                if (slots.HvacStatus.value == "off")
                {
                    if (thermostat.hvac_mode != HvacMode.off)
                        thermostat.hvac_mode = HvacMode.off;
                }
                else
                {
                    var hvacMode = (HvacMode)new HvacModeConverter().ConvertFrom((string)slots.HvacMode.value);
                    if (hvacMode != thermostat.hvac_mode)
                        thermostat.hvac_mode = hvacMode;
                }


                return string.Format("Thermostat mode set to {0}", thermostat.hvac_mode.Field());
            }
            catch (Exception ex)
            {
                return string.Format("Error occured. Unable to set mode. Error message... {0}", ex.Message);
            }
        }
    }
}
