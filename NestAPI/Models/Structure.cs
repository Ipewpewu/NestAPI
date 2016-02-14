using NestAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;

namespace NestAPI.Models
{
    public class Structure : NestObject
    {
        protected override string ObjectUrl { get { return string.Format("structures/{0}/", structure_id); } }

        public string structure_id { get; set; }
        public List<string> thermostats { get; set; }
        public List<string> smoke_co_alarms { get; set; }
        public List<string> cameras { get; set; }
        public dynamic devices { get; set; }
        [TypeConverter(typeof(AwaySateConverter))]
        public AwayState away { get; set; }
        public string name { get; set; }
        public string country_code { get; set; }
        public string postal_code { get; set; }
        public DateTime? peak_period_start_time { get; set; }
        public DateTime? peak_period_end_time { get; set; }
        public string time_zone { get; set; }
        public Eta eta { get; set; }
        public bool rhr_enrollment { get; set; }
        public List<Where> wheres { get; set; }

        public class Eta
        {
            public string trip_id { get; set; }
            public DateTime? estimated_arrival_window_begin { get; set; }
            public DateTime? estimated_arrival_window_end { get; set; }
        }
        public class Where
        {
            public string where_id { get; set; }
            public string name { get; set; }
        }
    }
}
