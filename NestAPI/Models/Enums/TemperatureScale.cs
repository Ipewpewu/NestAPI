﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace NestAPI.Models.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TemperatureScale
    {
        F,
        C
    }
}
