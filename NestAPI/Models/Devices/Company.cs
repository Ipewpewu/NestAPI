using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Devices
{
    public class Company
    {
        public ProductType product_type { get; set; }

        public class ProductType
        {
            public Identification identification { get; set; }
            public Location location { get; set; }
            public Software software { get; set; }
            public ResourceUse resource_use { get; set; }

            public class Identification
            {
                public string device_id { get; set; }
                public string serial_number { get; set; }
            }
            public class Location
            {
                public string structure_id { get; set; }
                public string where_id { get; set; }
            }
            public class Software
            {
                public string version { get; set; }
            }
            public class ResourceUse
            {
                public Resource electricity { get; set; }
                public Resource gas { get; set; }
                public Resource water { get; set; }

                public class Resource
                {
                    public float value { get; set; }
                    public DateTime? measurement_reset_time { get; set; }
                    public DateTime? measurement_time { get; set; }
                }
            }
        }
    }
    
}
