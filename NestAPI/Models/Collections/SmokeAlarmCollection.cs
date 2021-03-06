﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;
using NestAPI.Models.Devices;
using Newtonsoft.Json.Linq;

namespace NestAPI.Models.Collections
{
    public class SmokeAlarmCollection : NestCollection<SmokeAlarm>
    {
        protected override string ObjectUrl
        {
            get
            {
                return "devices/smoke_co_alarms";
            }
        }
        public static implicit operator SmokeAlarmCollection(JObject jsonList)
        {
            return To<SmokeAlarmCollection>(jsonList);
        }
    }
}
