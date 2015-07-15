namespace CourseBooking
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;

    using CourseBooking.QueryServices;

    public class Bootstrapper
    {
        /// <summary>
        /// The init.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public static void Init(IWindsorContainer container)
        {
            //container.Register(
            //    Component.For<IHubContextManager>().ImplementedBy<HubContextManager>().LifestyleTransient());

            container.Register(
                Component.For<ICourseQueryService>().ImplementedBy<CourseQueryService>().LifestyleTransient());

            container.Register(
                Component.For<IPersonQueryService>().ImplementedBy<PersonQueryService>().LifestyleTransient());
        }
    }
}