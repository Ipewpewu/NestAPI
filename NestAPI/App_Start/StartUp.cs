using Owin;
using System.Web.Http;

namespace NestAPI.App_Start
{
    public class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
                );

            appBuilder.UseWebApi(config);
        }
    }
}