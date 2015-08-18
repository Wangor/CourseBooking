// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PriceCalculationController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The price calculation controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CourseBooking.Models;

namespace CourseBooking.Controllers
{
    /// <summary>
    /// The price calculation controller.
    /// </summary>
    public class PriceCalculationController : Controller
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly CourseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceCalculationController"/> class.
        /// </summary>
        public PriceCalculationController()
        {
            context = new CourseContext();
        }

        // GET: PriceCalculation
        /// <summary>
        /// The calculate a 1.
        /// </summary>
        /// <param name="course1">
        /// The course 1.
        /// </param>
        /// <param name="course2">
        /// The course 2.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult CalculateA1(int course1, int course2)
        {
            Course c1 = context.Courses.FirstOrDefault(r => r.Id == course1);
            Course c2 = context.Courses.FirstOrDefault(r => r.Id == course2);
            if ((c1 != null) && (c2 != null))
            {
                var cost1 = Convert.ToInt32(c1.Price);
                var cost2 = Convert.ToInt32(c2.Price);
                return Json(new {course1 = cost1, course2 = cost2, fee = 50, total = ( cost1 + cost2 + 50 ) });
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult CalculateAWithA1(int course1, int course2)
        {
            Course c1 = context.Courses.FirstOrDefault(r => r.Id == course1);
            Course c2 = context.Courses.FirstOrDefault(r => r.Id == course2);
            if ((c1 != null) && (c2 != null))
            {
                var cost1 = Convert.ToInt32(c1.Price);
                var cost2 = Convert.ToInt32(c2.Price);
                return Json(new { course1 = cost1, course2 = cost2, fee = 50, total = (cost1 + cost2 + 50) });
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        public ActionResult CalculateA(int course1, int course2, int course3)
        {
            Course c1 = context.Courses.FirstOrDefault(r => r.Id == course1);
            Course c2 = context.Courses.FirstOrDefault(r => r.Id == course2);
            Course c3 = context.Courses.FirstOrDefault(r => r.Id == course3);
            if ((c1 != null) && (c2 != null) && (c2 != null))
            {
                var cost1 = Convert.ToInt32(c1.Price);
                var cost2 = Convert.ToInt32(c2.Price);
                var cost3 = Convert.ToInt32(c3.Price);
                return Json(new { course1 = cost1, course2 = cost2, course3 = cost3, fee = 50, total = (cost1 + cost2 + cost3 + 50) });
            }

            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }
    }
}