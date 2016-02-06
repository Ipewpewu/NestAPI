using NestAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Devices
{
    public class Thermostat
    {
        public string device_id { get; set; }
        public string locale { get; set; }
        public string software_version { get; set; }
        public string structure_id { get; set; }
        public string name { get; set; }
        public string name_long { get; set; }
        public DateTime? last_connection { get; set; }
        public bool is_online { get; set; }
        public bool can_cool { get; set; }
        public bool can_heat { get; set; }
        public bool is_using_emergency_heat { get; set; }
        public bool has_fan { get; set; }
        public bool fan_timer_active { get; set; }
        public DateTime? fan_timer_timeout { get; set; }
        public bool has_leaf { get; set; }
        public TemperatureScale temperature_scale { get; set; }
        public float target_temperature_f { get; set; }
        public float target_temperature_c { get; set; }
        public float target_temperature_high_f { get; set; }
        public float target_temperature_high_c { get; set; }
        public float target_temperature_low_f { get; set; }
        public float target_temperature_low_c { get; set; }
        public float away_temperature_high_f { get; set; }
        public float away_temperature_high_c { get; set; }
        public float away_temperature_low_f { get; set; }
        public float away_temperature_low_c { get; set; }
        public HvacMode hvac_mode { get; set; }
        public float ambient_temperature_f { get; set; }
        public float ambient_temperature_c { get; set; }
        public float humidity { get; set; }
        public HvacState hvac_state { get; set; }
        public string where_id { get; set; }        
    }
}
