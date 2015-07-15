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

    public class LocationsController : Controller
    {
        private CourseContext context;

        public LocationsController()
        {
            context = new CourseContext();
        }
        // GET: Locations
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetLocations([DataSourceRequest] DataSourceRequest request)
        {
            var result = context.Locations.ToList().ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetLocationsDL()
        {
            var result = context.Locations.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Location_Create([DataSourceRequest] DataSourceRequest dsRequest, Location location)
        {
            if (location != null && ModelState.IsValid)
            {
                context.Locations.Add(location);
                context.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
        }

        public ActionResult Location_Update([DataSourceRequest] DataSourceRequest dsRequest, Location location)
        {
            if (location != null && ModelState.IsValid)
            {
                var toUpdate = context.Locations.FirstOrDefault(p => p.Id == location.Id);
                TryUpdateModel(toUpdate);
                context.SaveChanges();
            }
            return Json(ModelState.ToDataSourceResult());
        }
    }
}