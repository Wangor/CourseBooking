// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseSetController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The course set controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using CourseBooking.Models;

namespace CourseBooking.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web.Mvc;

  using Kendo.Mvc.Extensions;
  using Kendo.Mvc.UI;

  /// <summary>
  /// The course set controller.
  /// </summary>
  public class CourseSetController : Controller
    {
    /// <summary>
    /// The context.
    /// </summary>
    private CourseContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CourseSetController"/> class.
    /// </summary>
    public CourseSetController()
        {
          this.context = new CourseContext();
        }
        // GET: CourseSet
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
          var courseSet = this.context.CourseSets.SingleOrDefault(c => c.Id == id);
          return this.View(courseSet);
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
        [ActionName("GetCourseSets")]
        public ActionResult GetCourseSets([DataSourceRequest] DataSourceRequest request, int? setId)
        {
          var courses = this.context.CourseSets.ToList();
          return this.Json(courses.ToDataSourceResult(request));
        }

        [ActionName("GetCourseSetEntries")]
        public ActionResult GetCourseSetEntries([DataSourceRequest] DataSourceRequest request, int? courseSetId)
        {
          var entries = this.context.CourseSetEntries.Include("CourseSet").Include("CourseTemplate").Where(e => e.CourseSet.Id == courseSetId).ToList();
          return this.Json(entries.ToDataSourceResult(request));
        }

        public ActionResult CreateCourseSet([DataSourceRequest] DataSourceRequest dsRequest, CourseSet courseSet)
        {
          if (courseSet != null && ModelState.IsValid)
          {
            this.context.CourseSets.Add(courseSet);
            this.context.SaveChanges();
          }

          return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult CreateCourseSetEntry([DataSourceRequest] DataSourceRequest dsRequest, CourseSetEntry courseSet)
        {
          if (courseSet != null && ModelState.IsValid)
          {
            var setId = Convert.ToInt32(courseSet.CourseSetId);
            var set = this.context.CourseSets.FirstOrDefault(t => t.Id == setId);
            var template = this.context.CourseTemplates.FirstOrDefault(t => t.Id == courseSet.CourseTemplate.Id);
            courseSet.CourseSet = set;
            courseSet.CourseTemplate = template;
            if (set.Entries == null)
            {
              set.Entries = new List<CourseSetEntry>();
            }
            set.Entries.Add(courseSet);
            this.context.SaveChanges();
          }

          return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult UpdateCourseSet([DataSourceRequest] DataSourceRequest dsRequest, CourseSet courseSet)
        {
          if (courseSet != null && ModelState.IsValid)
          {
            var toUpdate = this.context.CourseSets.FirstOrDefault(p => p.Id == courseSet.Id);
            this.TryUpdateModel(toUpdate);
            this.context.SaveChanges();
          }
          return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteCourseSet([DataSourceRequest] DataSourceRequest dsRequest, CourseSet courseSet)
        {
          this.context.CourseSets.Remove(this.context.CourseSets.SingleOrDefault(c => c.Id == courseSet.Id));
          this.context.SaveChanges();

          return this.Json(ModelState.ToDataSourceResult());
        }

        public ActionResult DeleteCourseSetEntry([DataSourceRequest] DataSourceRequest dsRequest, CourseSetEntry courseSetEntry)
        {
          this.context.CourseSetEntries.Remove(this.context.CourseSetEntries.SingleOrDefault(c => c.Id == courseSetEntry.Id));
          this.context.SaveChanges();

          return this.Json(ModelState.ToDataSourceResult());
        }
    }
}