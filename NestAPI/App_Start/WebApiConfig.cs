using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Reflection;
using NestAPI.App_Start;
using System.Diagnostics;

namespace NestAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ConfigureAuthToken();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "EchoApi",
                routeTemplate: "echo/api/{controller}/{action}"
            );
        }
        public static void ConfigureAuthToken()
        {            
            var authToken = string.Empty;
            using (var dbo = new NestEntities())
                authToken = dbo.ServiceAttributes.First(x => x.Name == "Auth.Token").Value;

            if(string.IsNullOrWhiteSpace(authToken))
            {
                var baseURL = "http://localhost:9000/";
                using (WebApp.Start<OnStart>(url: baseURL))
                {
                    var authUrl = string.Empty;
                    var stateGuid = Guid.NewGuid();
                    using (var dbo = new NestEntities())
                    {
                        var url = dbo.ServiceAttributes.First(x => x.Name == "Auth.CodeUrl").Value;
                        var clientId = dbo.ServiceAttributes.First(x => x.Name == "Client.Id").Value;
                        authUrl = string.Format(url, clientId, stateGuid);
                    }

                        
                        
                    Process.Start(authUrl);

                    var client = new HttpClient();
                    var readyResult = client.GetAsync(string.Format("{0}/api/OnStart/ReadyCheck", baseURL)).Result;                   
                }
            }            
        }

    }
}
