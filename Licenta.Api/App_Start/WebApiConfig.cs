using Licenta.Interfaces;
using Licenta.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Licenta.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IMapper, EntitiesMapper>();
            container.RegisterType<IRepository, DatabaseRepository>();
            container.RegisterType<ILogger, FileLogger>();
            container.RegisterType<IPasswordManager, PasswordManager>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
