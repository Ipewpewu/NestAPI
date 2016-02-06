using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace NestAPI.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UIColorState
    {
        gray,
        green,
        yellow,
        red
    }
}
