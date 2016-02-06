using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace NestAPI.App_Start
{
    public class StartupController : ApiController
    {
        [HttpGet]
        public void Auth(string state, string code)
        {            
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            config.AppSettings.Settings["auth-token"].Value = code;
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
