using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Controllers;
using AcadOracle.Dal;
using AcadOracle.Dal.Interfaces;
using SimpleInjector;

namespace AcadOracle.WebMVC.Infrastructure
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();

            // register Web API controllers (important!)
            var controllerTypes =
                from type in Assembly.GetExecutingAssembly().GetExportedTypes()
                where typeof(IHttpController).IsAssignableFrom(type) // (typeof(IHttpController).IsAssignableFrom(type) || (typeof(IController).IsAssignableFrom(type) && type.Name != "HelpController"))
                where !type.IsAbstract
                where !type.IsGenericTypeDefinition
                where type.Name.EndsWith("Controller", StringComparison.Ordinal)
                select type;

            foreach (var controllerType in controllerTypes)
            {
                container.Register(controllerType);
            }

            // Register your types, for instance:
            container.Register<ICursoRepository, CursoRepository>();
            container.Register<ITurmaRepository, TurmaRepository>();
            container.Register<IDisciplinaRepository, DisciplinaRepository>();
            container.Register<ITurmaHorarioRepository, TurmaHorarioRepository>();

            // register MVC controllers (This is an extension method from the integration package).
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // register MVC attributes (This is an extension method from the integration package as well).
            container.RegisterMvcAttributeFilterProvider();

            // Verify the container configuration
            container.Verify();

            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            System.Web.Mvc.DependencyResolver.SetResolver(
                new SimpleInjector.Integration.Web.Mvc.SimpleInjectorDependencyResolver(container));

        }
    }
}