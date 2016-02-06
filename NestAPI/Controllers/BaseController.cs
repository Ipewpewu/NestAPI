using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NestAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected readonly string AuthToken = ConfigurationManager.AppSettings["auth-token"];
    }
}
