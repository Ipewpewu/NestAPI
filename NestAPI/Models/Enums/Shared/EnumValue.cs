using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Enums.Shared
{
    [AttributeUsage(AttributeTargets.Field)]
    public class Value : System.Attribute
    {
        public string CompareValue { get; set; }
        public Value(string value)
        {
            CompareValue = value;
        }

    }

    public static class EnumValue
    {
        public static string Field(this System.Enum en)
        {
            var attributes = en.GetType().GetMember(en.ToString())[0].GetCustomAttributes(typeof(Value), false);

            if (attributes != null && attributes.Any())
                return ((Value)attributes[0]).CompareValue;
            return en.ToString();
        }

    }
}
