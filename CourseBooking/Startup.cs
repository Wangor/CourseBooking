using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseBooking.Startup))]
namespace CourseBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
