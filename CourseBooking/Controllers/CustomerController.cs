using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseBooking.Controllers
{
  using CourseBooking.Models;

  using Kendo.Mvc.Extensions;
  using Kendo.Mvc.UI;

  public class CustomerController : Controller
    {
    private CourseContext context;

    public CustomerController()
    {
      this.context = new CourseContext();
    }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The get customers.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [ActionName("GetCustomers")]
        public ActionResult GetCustomers([DataSourceRequest] DataSourceRequest request, int? customerId)
        {
          var customers = this.context.Customers.ToList();
          return this.Json(customers.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomersDL()
        {
          var customers = this.context.Customers.ToList();
          return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}