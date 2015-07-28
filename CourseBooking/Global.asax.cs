using System.Data.Entity.Migrations;
using CourseBooking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CourseBooking
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        protected void Application_Start()
        {
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            AreaRegistration.RegisterAllAreas();
            BootstrapContainer();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// The bootstrap container.
        /// </summary>
        private static void BootstrapContainer()
        {
            container = new WindsorContainer().Install(FromAssembly.This());

            //container.Register(Classes.FromThisAssembly().BasedOn<IHub>().LifestyleTransient());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
