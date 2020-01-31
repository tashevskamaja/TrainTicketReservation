using Autofac;
using Autofac.Integration.WebApi;
using WebApiTrainTicket.Filters;
using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Repository;
using OnlineTrainTicketReservation.Services;
using log4net;
using System.Reflection;
using System.Web.Http;


namespace WebApiTrainTicket.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // DI

            var builder = new ContainerBuilder();

            // Register all dependencies here
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<DatabaseRepo>().As<IDatabaseRepo>();
            builder.RegisterType<PassengerService>().As<IPassengerService>();
            builder.RegisterType<TrainService>().As<ITrainService>();          
            builder.Register(c => LogManager.GetLogger(typeof(object))).As<ILog>();
            builder.RegisterType<UserService>().As<IUserService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Filters.Add(new BasicAuthenticationAttribute(container.Resolve<IUserService>()));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
        }    
    }
}