using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;

namespace NestAPI.Models.Devices
{
    public class Camera : NestObject
    {
        protected override string ObjectUrl { get { return string.Format("devices/cameras/{0}/", device_id); } }

        public string device_id { get; private set; }
        public string software_version { get; private set; }
        public string structure_id { get; private set; }
        public string where_id { get; private set; }
        public string name { get; private set; }
        public string name_long { get; private set; }
        public bool is_online { get; private set; }
        public bool is_streaming { get; private set; }
        public bool is_audio_input_enabled { get; private set; }
        public DateTime? last_is_online_change { get; private set; }
        public bool is_video_history_enabled { get; private set; }
        public string web_url { get; private set; }
        public string app_url { get; private set; }
        public Event last_event { get; private set; }

        public class Event
        {
            public bool has_shound { get; private set; }
            public bool has_motion { get; private set; }
            public DateTime? start_time { get; private set; }
            public DateTime? end_time { get; private set; }
            public DateTime? url_expire_time { get; private set; }
            public string web_url { get; private set; }
            public string app_url { get; private set; }
            public string image_url { get; private set; }
            public string animated_image_url { get; private set; }
        }
    }
    
}
