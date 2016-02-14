using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Enums;
using NestAPI.Models.Base;

namespace NestAPI.Models.Devices
{
    public class SmokeAlarm : NestObject
    {
        protected override string ObjectUrl { get { return string.Format("devices/smoke_co_alarms/{0}/", device_id); } }
        public string device_id { get; private set; }
        public string locale { get; private set; }
        public string software_version { get; private set; }
        public string structure_id { get; private set; }
        public string name { get; private set; }
        public string name_long { get; private set; }
        public DateTime? last_connection { get; private set; }
        public bool is_online { get; private set; }
        public BatteryHealth battery_health { get; private set; }
        public COAlarmState co_alarm_state { get; private set; }
        public SmokeAlarmState smoke_alarm_state { get; private set; }
        public bool is_manual_test_active { get; private set; }
        public DateTime? last_manual_test_time { get; private set; }
        public UIColorState ui_color_state { get; set; }
        public string where_id { get; private set; }
    }
}
