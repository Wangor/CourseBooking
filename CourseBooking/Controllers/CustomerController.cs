using System.Collections.Generic;
using CourseBooking.ViewModels;

namespace CourseBooking.Controllers
{
    using System.Linq;
  using System.Web.Mvc;
    using Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    [Authorize]
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

    public ActionResult GetCustomerCourses([DataSourceRequest] DataSourceRequest request, int? customerId)
    {
        var customer = this.context.Customers.Include("Registrations").FirstOrDefault(c => c.Id == customerId);
        var list = new List<RegistrationsViewModel>();
        
        foreach (var registration in customer.Registrations)
        {
            var reg = new RegistrationsViewModel(registration);
            list.Add(reg);
        }
        return this.Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
    }
    }
}