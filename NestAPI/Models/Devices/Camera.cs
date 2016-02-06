using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Devices
{
    public class Camera
    {
        public string device_id { get; set; }
        public string software_version { get; set; }
        public string structure_id { get; set; }
        public string where_id { get; set; }
        public string name { get; set; }
        public string name_long { get; set; }
        public bool is_online { get; set; }
        public bool is_streaming { get; set; }
        public bool is_audio_input_enabled { get; set; }
        public DateTime? last_is_online_change { get; set; }
        public bool is_video_history_enabled { get; set; }
        public string web_url { get; set; }
        public string app_url { get; set; }
        public Event last_event { get; set; }

        public class Event
        {
            public bool has_shound { get; set; }
            public bool has_motion { get; set; }
            public DateTime? start_time { get; set; }
            public DateTime? end_time { get; set; }
            public DateTime? url_expire_time { get; set; }
            public string web_url { get; set; }
            public string app_url { get; set; }
            public string image_url { get; set; }
            public string animated_image_url { get; set; }
        }
    }
    
}
