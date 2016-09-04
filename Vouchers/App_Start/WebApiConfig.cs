using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Dominos.OLO.Vouchers
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Error Handler
            config.Services.Replace(typeof(IExceptionHandler), new Logging.GlobalExceptionHandler());


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
