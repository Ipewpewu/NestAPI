using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Enums
{
    public sealed class HvacMode
    {
        public static readonly HvacMode Off = new HvacMode("off");
        public static readonly HvacMode Cool = new HvacMode("cool");
        public static readonly HvacMode Heat = new HvacMode("heat");
        public static readonly HvacMode HeatCool = new HvacMode("heat-cool");

        private static readonly SortedList<string, HvacMode> Values = new SortedList<string, HvacMode>();
        private readonly string Value;

        private HvacMode(string value)
        {
            this.Value = value;
            Values.Add(value, this);
        }
        public static implicit operator HvacMode(string value)
        {
            return Values[value];
        }
        public static implicit operator string(HvacMode value)
        {
            return value.Value;
        }
    }
}
