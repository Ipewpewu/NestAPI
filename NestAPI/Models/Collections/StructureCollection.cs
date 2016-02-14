using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Base;
using NestAPI.Models.Devices;
using Newtonsoft.Json.Linq;

namespace NestAPI.Models.Collections
{
    public class StructureCollection : NestCollection<Structure>
    {
        protected override string ObjectUrl
        {
            get
            {
                return "structures";
            }
        }
        public static implicit operator StructureCollection(JObject jsonList)
        {
            return To<StructureCollection>(jsonList);
        }
    }
}
