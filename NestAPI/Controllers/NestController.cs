using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NestAPI.Controllers
{
    public class NestController : BaseController
    {
        [HttpPost]
        public dynamic SetTemperature(dynamic slots)
        {
            return slots;
        }

    }
}
