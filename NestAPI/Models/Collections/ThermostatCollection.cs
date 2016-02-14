using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;
using NestAPI.Models.Devices;
using Newtonsoft.Json.Linq;

namespace NestAPI.Models.Collections
{
    public class ThermostatCollection : NestCollection<Thermostat>
    {
        protected override string ObjectUrl
        {
            get
            {
                return "devices/thermostats";
            }
        }
        public static implicit operator ThermostatCollection(JObject jsonList)
        {
            return To<ThermostatCollection>(jsonList);
        }
    }
}
