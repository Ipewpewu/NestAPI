using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NestAPI.Models.Enums.Shared;
using System.ComponentModel;
using System.Globalization;

namespace NestAPI.Models.Enums
{
    public enum AwayState
    {
        home,
        away,
        [Value("auto-away")]
        autoAway
    }
    public class AwaySateConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                var mode = (string)value;

                if (mode == AwayState.home.ToString()) return AwayState.home;
                else if (mode == AwayState.away.ToString()) return AwayState.away;
                else if (mode == AwayState.autoAway.ToString()) return AwayState.autoAway;

            }
            else if (value is AwayState)
                return value;

            return base.ConvertFrom(context, culture, value);
        }
    }

    
}
