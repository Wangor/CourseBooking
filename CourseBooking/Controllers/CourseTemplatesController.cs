using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseBooking.Models;

namespace CourseBooking.Controllers
{
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class CourseTemplatesController : Controller
    {
        private CourseContext context;

        public CourseTemplatesController()
        {
            context = new CourseContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCourseTemplates([DataSourceRequest] DataSourceRequest request)
        {
            var result = context.CourseTemplates.ToList().ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourseTemplatesDL()
        {
            var result = context.CourseTemplates.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCourseTemplate(int? id)
        {
            var result = context.CourseTemplates.FirstOrDefault(t => t.Id == id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CourseTemplate_Create([DataSourceRequest] DataSourceRequest dsRequest, CourseTemplate courseTemplate)
        {
          if (courseTemplate != null && ModelState.IsValid)
            {
              context.CourseTemplates.Add(courseTemplate);
                context.SaveChanges();
            }
            return Json(new[] { courseTemplate }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult CourseTemplate_Update([DataSourceRequest] DataSourceRequest dsRequest, CourseTemplate courseTemplate)
        {
          if (courseTemplate != null && ModelState.IsValid)
            {
              var toUpdate = context.CourseTemplates.FirstOrDefault(p => p.Id == courseTemplate.Id);
                TryUpdateModel(toUpdate);
                context.SaveChanges();
            }
            return Json(new[] { courseTemplate }.ToDataSourceResult(dsRequest, ModelState));
        }

        public ActionResult DeleteCourseTemplate([DataSourceRequest] DataSourceRequest dsRequest, CourseTemplate courseTemplate)
        {
          if (courseTemplate != null && ModelState.IsValid)
            {
              this.context.CourseTemplates.Remove(this.context.CourseTemplates.SingleOrDefault(c => c.Id == courseTemplate.Id));
                this.context.SaveChanges();
            }

            return Json(new[] { courseTemplate }.ToDataSourceResult(dsRequest, ModelState));
        }
    }
}