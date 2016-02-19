using NestAPI.Models.Enums.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Enums
{
    public enum HvacMode
    {
        Unknown,
        off,
        cool,
        heat,
        [Value("heat-cool")]
        heatCool
    }
    public class HvacModeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var mode = (string)value;

                if (mode == HvacMode.cool.ToString()) return HvacMode.cool;
                else if (mode == HvacMode.heat.ToString()) return HvacMode.heat;
                else if (mode == HvacMode.off.ToString()) return HvacMode.off;
                else if (mode == HvacMode.heatCool.Field()) return HvacMode.heatCool;

            }
            else if (value is HvacMode)
                return value;

            return base.ConvertFrom(context, culture, value);
        }
    }
}
