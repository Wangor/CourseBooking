// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoursesController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CoursesController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CourseBooking.Models;

namespace CourseBooking.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    /// <summary>
    /// The courses controller.
    /// </summary>
    public class CoursesController : Controller
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly CourseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoursesController"/> class.
        /// </summary>
        public CoursesController()
        {
            this.context = new CourseContext();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult List()
        {
            return this.View();
        }

        /// <summary>
        /// The get courses.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ActionName("GetCourses")]
        public ActionResult GetCourses([DataSourceRequest] DataSourceRequest request, int? templateId)
        {
            var courses = this.context.Courses.ToList();
            return this.Json(courses.ToDataSourceResult(request));
        }

        public ActionResult GetCourseDL(int templateId, int previous = 0)
        {
          var result = context.Courses.Where(c => c.CourseTemplateId == templateId).ToList();
          var listItems = new List<CourseListViewModel>();
          foreach (var item in result)
          {
            var li = new CourseListViewModel();
            li.SetInfo(item);
            listItems.Add(li);
          }
          return Json(listItems, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Course_Create([DataSourceRequest] DataSourceRequest dsRequest, Course course)
        {
            if (course != null && ModelState.IsValid)
            {
                this.context.Courses.Add(course);
                this.context.SaveChanges();
            }

            return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteCourse([DataSourceRequest] DataSourceRequest dsRequest, Course course)
        {
            this.context.Courses.Remove(this.context.Courses.SingleOrDefault(c=>c.Id == course.Id));
            this.context.SaveChanges();

            return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Course_Update([DataSourceRequest] DataSourceRequest dsRequest, Course course)
        {
           
          if (course != null && ModelState.IsValid)
            {
                var toUpdate = this.context.Courses.FirstOrDefault(p => p.Id == course.Id);
                this.TryUpdateModel(toUpdate);
                this.context.SaveChanges();
            }
            return this.Json(ModelState.ToDataSourceResult());
        }
    }

  public class CourseListViewModel
  {
    public int Id { get; set; }

    public string DisplayName { get; set; }

    public void SetInfo(Course course)
    {
      Id = course.Id;
      DisplayName = String.Format("{0} - {1} - {2}", course.Name, course.StartDateTime, course.Price);
    }
  }
}