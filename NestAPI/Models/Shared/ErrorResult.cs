using NestAPI.Models.Base;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Shared
{
    public class ErrorResult
    {
        public bool IsError { get { return !string.IsNullOrWhiteSpace(error); } }
        public string error { get; set; }
        public string type { get; set; }
        public Guid instance { get; set; }
        public string message { get; set; }
        public dynamic details { get; set; }

        public static implicit operator ErrorResult(JObject jsonObject)
        {
            try
            {
                var obj = new ErrorResult();
                var properties = obj.GetType().GetProperties();

                foreach (var pi in properties)
                {
                    dynamic value = null;
                    value = jsonObject.GetValue(pi.Name);
                    if (value != null)
                    {
                        try
                        {
                            pi.SetValue(obj, value.Value, null);
                        }
                        catch (Exception)
                        {
                            var converter = TypeDescriptor.GetProperties(obj)[pi.Name].Converter;
                            pi.SetValue(obj, converter.ConvertFrom(value.Value), null);
                        }
                    }
                }

                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
