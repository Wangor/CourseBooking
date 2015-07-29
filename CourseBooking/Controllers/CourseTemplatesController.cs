// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseTemplatesController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The course templates controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace CourseBooking.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    /// <summary>
    /// The course templates controller.
    /// </summary>
    [Authorize]
    public class CourseTemplatesController : Controller
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly CourseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseTemplatesController"/> class.
        /// </summary>
        public CourseTemplatesController()
        {
            context = new CourseContext();
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The get course templates.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult GetCourseTemplates([DataSourceRequest] DataSourceRequest request)
        {
            DataSourceResult result = context.CourseTemplates.ToList().ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The get course templates dl.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult GetCourseTemplatesDL()
        {
            List<CourseTemplate> result = context.CourseTemplates.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The get course template.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult GetCourseTemplate(int? id)
        {
            CourseTemplate result = context.CourseTemplates.FirstOrDefault(t => t.Id == id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The course template_ create.
        /// </summary>
        /// <param name="dsRequest">
        /// The ds request.
        /// </param>
        /// <param name="courseTemplate">
        /// The course template.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult CourseTemplate_Create([DataSourceRequest] DataSourceRequest dsRequest, 
            CourseTemplate courseTemplate)
        {
            if (courseTemplate != null && ModelState.IsValid)
            {
                context.CourseTemplates.Add(courseTemplate);
                context.SaveChanges();
            }

            return Json(new[] {courseTemplate}.ToDataSourceResult(dsRequest, ModelState));
        }

        /// <summary>
        /// The course template_ update.
        /// </summary>
        /// <param name="dsRequest">
        /// The ds request.
        /// </param>
        /// <param name="courseTemplate">
        /// The course template.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult CourseTemplate_Update([DataSourceRequest] DataSourceRequest dsRequest, 
            CourseTemplate courseTemplate)
        {
            if (courseTemplate != null && ModelState.IsValid)
            {
                CourseTemplate toUpdate = context.CourseTemplates.FirstOrDefault(p => p.Id == courseTemplate.Id);
                TryUpdateModel(toUpdate);
                context.SaveChanges();
            }

            return Json(new[] {courseTemplate}.ToDataSourceResult(dsRequest, ModelState));
        }

        /// <summary>
        /// The delete course template.
        /// </summary>
        /// <param name="dsRequest">
        /// The ds request.
        /// </param>
        /// <param name="courseTemplate">
        /// The course template.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult DeleteCourseTemplate([DataSourceRequest] DataSourceRequest dsRequest, 
            CourseTemplate courseTemplate)
        {
            if (courseTemplate != null && ModelState.IsValid)
            {
                context.CourseTemplates.Remove(context.CourseTemplates.SingleOrDefault(c => c.Id == courseTemplate.Id));
                context.SaveChanges();
            }

            return Json(new[] {courseTemplate}.ToDataSourceResult(dsRequest, ModelState));
        }
    }
}