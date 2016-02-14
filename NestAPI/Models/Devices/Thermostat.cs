using NestAPI.Models.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;
using NestAPI.Models.Enums.Shared;

namespace NestAPI.Models.Devices
{
    public class Thermostat : NestObject
    {
        protected override string ObjectUrl { get { return string.Format("devices/thermostats/{0}/", device_id); } }        

        public string device_id { get; private set; }
        public string locale { get; private set; }
        public string software_version { get; private set; }
        public string structure_id { get; private set; }
        public string name { get; private set; }
        public string name_long { get; private set; }
        public DateTime? last_connection { get; private set; }
        public bool is_online { get; private set; }
        public bool can_cool { get; private set; }
        public bool can_heat { get; private set; }
        public bool is_using_emergency_heat { get; private set; }
        public bool has_fan { get; private set; }
        public bool fan_timer_active { get; private set; }
        public DateTime? fan_timer_timeout { get; set; }
        public bool has_leaf { get; private set; }
        public TemperatureScale temperature_scale { get; private set; }

        private float _target_temperature_f;
        public float target_temperature_f
        {
            get { return _target_temperature_f; }
            set
            {
                if (_target_temperature_f == 0 || Set("target_temperature_f", value.ToString()))
                    _target_temperature_f = value;
            }
        }
        private double _target_temperature_c;
        public double target_temperature_c
        {
            get { return _target_temperature_c; }
            set
            {
                if (_target_temperature_c == 0 || Set("target_temperature_c", value.ToString()))
                    _target_temperature_c = value;
            }
        }

        private float _target_temperature_high_f;
        public float target_temperature_high_f
        {
            get { return _target_temperature_high_f; }
            set
            {
                if (_target_temperature_high_f == 0 || Set("target_temperature_high_f", value.ToString()))
                    _target_temperature_high_f = value;
            }
        }
        private double _target_temperature_high_c;
        public double target_temperature_high_c
        {
            get { return _target_temperature_high_c; }
            set
            {
                if (_target_temperature_high_c == 0 || Set("target_temperature_high_C", value.ToString()))
                    _target_temperature_high_c = value;
            }
        }

        private float _target_temperature_low_f;
        public float target_temperature_low_f
        {
            get { return _target_temperature_low_f; }
            set
            {
                if (_target_temperature_low_f == 0 || Set("target_temperature_low_f", value.ToString()))
                    _target_temperature_low_f = value;
            }
        }
        private double _target_temperature_low_c;
        public double target_temperature_low_c
        {
            get { return _target_temperature_low_c; }
            set
            {
                if (_target_temperature_low_c == 0 || Set("target_temperature_low_C", value.ToString()))
                    _target_temperature_low_c = value;
            }
        }

        public float away_temperature_high_f { get; private set; }
        public double away_temperature_high_c { get; private set; }
        public float away_temperature_low_f { get; private set; }
        public double away_temperature_low_c { get; private set; }

        private HvacMode _hvac_mode = HvacMode.Unknown;
        [TypeConverter(typeof(HvacModeConverter))]
        public HvacMode hvac_mode
        {
            get { return _hvac_mode; }
            set
            {
                if (_hvac_mode == HvacMode.Unknown || Set("hvac_mode", value.Field()))
                    _hvac_mode = value;
            }
        }

        public float ambient_temperature_f { get; private set; }
        public double ambient_temperature_c { get; private set; }
        public float humidity { get; private set; }
        public HvacState hvac_state { get; private set; }
        public string where_id { get; private set; }

        public static implicit operator Thermostat(JObject jsonObject)
        {
            var thermostat = new Thermostat();

            var properties = thermostat.GetType().GetProperties();

            foreach (var pi in properties)
            {
                dynamic value = null;
                value = jsonObject.GetValue(pi.Name);
                if (value != null)
                {
                    try
                    {
                        pi.SetValue(thermostat, value.Value, null);
                    }
                    catch (Exception)
                    {
                        var converter = TypeDescriptor.GetProperties(thermostat)[pi.Name].Converter;
                        pi.SetValue(thermostat, converter.ConvertFrom(value.Value), null);
                    }


                }

            }

            return thermostat;
        }
    }
}
