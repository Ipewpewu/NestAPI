using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Collections;

namespace NestAPI.Models.Devices
{
    public class Devices
    {
        private ThermostatCollection _thermostats;
        public ThermostatCollection thermostats
        {
            get
            {
                if (_thermostats == null)
                    _thermostats = ThermostatCollection.Get<ThermostatCollection>();
                return _thermostats;
            }
            private set { _thermostats = value; }
        }

        private SmokeAlarmCollection _smoke_co_alarms;
        public SmokeAlarmCollection smoke_co_alarms
        {
            get
            {
                if (_smoke_co_alarms == null)
                    _smoke_co_alarms = SmokeAlarmCollection.Get<SmokeAlarmCollection>();
                return _smoke_co_alarms;
            }
            private set { _smoke_co_alarms = value; }
        }

        private CameraCollection _cameras;
        public CameraCollection cameras
        {
            get
            {
                if (_cameras == null)
                    _cameras = CameraCollection.Get<CameraCollection>();
                return _cameras;
            }
            private set { _cameras = value; }
        }
        
        private Company _company;
        public Company company
        {
            get
            {
                if (_company == null)
                    _company = Company.Get<Company>();
                return _company;
            }
            private set { _company = value; }
        }
    }
}
