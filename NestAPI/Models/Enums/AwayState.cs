using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Enums
{
    public sealed class AwaySate
    {
        public static readonly AwaySate Home = new AwaySate("home");
        public static readonly AwaySate Away = new AwaySate("away");
        public static readonly AwaySate AutoAway = new AwaySate("auto-away");

        private static readonly SortedList<string, AwaySate> Values = new SortedList<string, AwaySate>();
        private readonly string Value;

        private AwaySate(string value)
        {
            this.Value = value;
            Values.Add(value, this);
        }
        public static implicit operator AwaySate(string value)
        {
            return Values[value];
        }
        public static implicit operator string (AwaySate value)
        {
            return value.Value;
        }
    }
}
