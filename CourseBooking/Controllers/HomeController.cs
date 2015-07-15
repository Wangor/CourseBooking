// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CourseBooking.Models;

namespace CourseBooking.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new CourseContext();
            var courses = context.Courses.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}