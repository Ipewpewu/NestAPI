using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;

namespace NestAPI.Models.Devices
{
    public class Company : NestObject
    {
        protected override string ObjectUrl { get { return string.Format("?"); } }

        public ProductType product_type { get; set; }

        public class ProductType
        {
            public Identification identification { get; private set; }
            public Location location { get; private set; }
            public Software software { get; private set; }
            public ResourceUse resource_use { get; private set; }

            public class Identification
            {
                public string device_id { get; private set; }
                public string serial_number { get; private set; }
            }
            public class Location
            {
                public string structure_id { get; private set; }
                public string where_id { get; private set; }
            }
            public class Software
            {
                public string version { get; private set; }
            }
            public class ResourceUse
            {
                public Resource electricity { get; private set; }
                public Resource gas { get; private set; }
                public Resource water { get; private set; }

                public class Resource
                {
                    public float value { get; private set; }
                    public DateTime? measurement_reset_time { get; private set; }
                    public DateTime? measurement_time { get; private set; }
                }
            }
        }
    }
    
}
