using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Enums;

namespace NestAPI.Models.Devices
{
    public class SmokeAlarm
    {
        public string device_id { get; set; }
        public string locale { get; set; }
        public string software_version { get; set; }
        public string structure_id { get; set; }
        public string name { get; set; }
        public string name_long { get; set; }
        public DateTime? last_connection { get; set; }
        public bool is_online { get; set; }
        public BatteryHealth battery_health { get; set; }
        public COAlarmState co_alarm_state { get; set; }
        public SmokeAlarmState smoke_alarm_state { get; set; }
        public bool is_manual_test_active { get; set; }
        public DateTime? last_manual_test_time { get; set; }
        public UIColorState ui_color_state { get; set; }
        public string where_id { get; set; }
    }
}
