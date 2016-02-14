using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Devices;
using NestAPI.Models.Collections;

namespace NestAPI.Models
{
    public class Nest
    {
        public MetaData metadata { get; set; }
        public Devices.Devices devices { get; set; }


        private StructureCollection _structures;
        public StructureCollection structures
        {
            get
            {
                if (_structures == null)
                    _structures = StructureCollection.Get<StructureCollection>();
                return _structures;
            }
            private set { _structures = value; }
        }

        public Nest()
        {
            metadata = new MetaData();
            devices = new Devices.Devices();
        }
    }
}
