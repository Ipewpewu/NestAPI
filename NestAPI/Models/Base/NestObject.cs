using NestAPI.Models.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NestAPI.Models.Base
{
    public abstract class NestObject
    {
        private static readonly string DefaultUrl = "https://developer-api.nest.com/";

        private static string _authToken;
        private static string AuthToken
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_authToken))
                {
                    using (var dbo = new NestEntities())
                        _authToken = dbo.ServiceAttributes.First(x => x.Name == "Auth.Token").Value;
                }
                return _authToken;
            }
        }
        private static string BaseUrl = DefaultUrl;

        protected abstract string ObjectUrl { get; }

        public string Url
        {
            get
            {                
                return string.Format("{0}{1}?auth={2}", BaseUrl, ObjectUrl, AuthToken);
            }
        }

        public HttpStatusCode StatusCode { get; protected set; }
        public string ReasonPhrase { get; protected set; }

        public static T Get<T>() where T : NestObject, new()
        {
            var obj = new T();
            var response = SendRequest(obj);
            var result = ProcessResponse(response);

            return result == null ? null : (T)result;
        }
        protected bool Set(string field, string value, bool wrapInQuotes = false)
        {
            var wrapValue = wrapInQuotes ? "\"" : string.Empty;
            var setStr = string.Format("{{\"{0}\":{2}{1}{2}}}", field, value, wrapValue);
            var content = new StringContent(setStr);
            return Set(content);
        }
        protected bool Set(StringContent jsonContent)
        {
            var response = SendRequest(this, jsonContent);
            return ProcessResponse(response) != null; 
        }
                  
        public static T To<T>(JObject jsonObject) where T : NestObject, new()
        {
            try
            {
                var obj = new T();
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
        public virtual void Refresh() { }

        private static HttpResponseMessage SendRequest(NestObject obj, StringContent jsonContent = null)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var method = jsonContent == null
                    ? client.GetType().GetMethod("GetAsync", new Type[] { typeof(string) })
                    : client.GetType().GetMethod("PutAsync", new Type[] { typeof(string), typeof(StringContent) });

                    var parameters = jsonContent == null ? new object[] { obj.Url } : new object[] { obj.Url, jsonContent };

                    var response = (HttpResponseMessage)((dynamic)method.Invoke(client, parameters)).Result;

                    try
                    {
                        var newUrl = string.Empty;
                        while (response.StatusCode == HttpStatusCode.TemporaryRedirect && response.Headers.Location != null && (newUrl = response.Headers.Location.ToString()) != BaseUrl)
                        {
                            newUrl = newUrl.Substring(0, newUrl.IndexOf("/auth="));
                            BaseUrl = newUrl;

                            parameters[0] = obj.Url;

                            response = (HttpResponseMessage)((dynamic)method.Invoke(client, parameters)).Result;
                        }
                        return response;
                    }
                    catch (Exception ex)
                    {
                        BaseUrl = DefaultUrl;
                        parameters[0] = obj.Url;
                        return (HttpResponseMessage)((dynamic)method.Invoke(client, parameters)).Result;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        private static dynamic ProcessResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<JObject>(response.Content.ReadAsStringAsync().Result);

                var error = (ErrorResult)result;
                if (error != null && error.IsError)
                {

                }
                else
                    return result;
            }

            return null;
        }
    }
}
