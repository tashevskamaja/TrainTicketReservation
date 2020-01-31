using System.Web.Http;
using WebActivatorEx;
using WebApiTrainTicket;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiTrainTicket
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApiTrainTicket");
                    })
                .EnableSwaggerUi();
        }
    }
}
