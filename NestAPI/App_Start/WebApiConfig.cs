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
            var baseURL = "http://localhost:9000/";
            using (WebApp.Start<StartUp>(url: baseURL))
            {
                if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["auth-token"]))
                {
                    var stateGuid = Guid.NewGuid();
                    var authURL = string.Format(ConfigurationManager.AppSettings["auth-url"], ConfigurationManager.AppSettings["client-id"], stateGuid);
                    Process.Start(authURL);
                }
            }
        }

    }
}
