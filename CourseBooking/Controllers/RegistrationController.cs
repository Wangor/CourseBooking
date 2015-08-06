// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationController.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the RegistrationController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Threading;
using CourseBooking.Services;

namespace CourseBooking.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Web.Mvc;

  using CourseBooking.Models;
  using CourseBooking.ViewModels;

  using Kendo.Mvc.Extensions;
  using Kendo.Mvc.UI;

  /// <summary>
  /// The registration controller.
  /// </summary>
  public class RegistrationController : Controller
  {

      protected override void Initialize(System.Web.Routing.RequestContext requestContext)
      {
          base.Initialize(requestContext);

          const string culture = "de-CH";
          CultureInfo ci = CultureInfo.GetCultureInfo(culture);

          Thread.CurrentThread.CurrentCulture = ci;
          Thread.CurrentThread.CurrentUICulture = ci;
      }


    #region Fields

    /// <summary>
    /// The context.
    /// </summary>
    private readonly CourseContext context;

    #endregion

    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegistrationController"/> class.
    /// </summary>
    public RegistrationController()
    {
      this.context = new CourseContext();
    }

    #endregion

    #region Public Methods and Operators

    /// <summary>
    /// The assign registration.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult AssignRegistration(int id)
    {
      var registration = context.Registrations.Include("Courses").FirstOrDefault(c => c.Id == id);
      var vm = new AssignRegistrationViewModel(registration);
      return this.View(vm);
    }

    /// <summary>
    /// The confirm.
    /// </summary>
    /// <param name="id">
    /// The id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult Confirm(int id)
    {
      Registration registration = this.context.Registrations.FirstOrDefault(r => r.Id == id);
      if (registration != null)
      {
        registration.Confirmed = true;
        try
        {
            MailService.ConfirmRegistration(id);
          this.context.SaveChanges();
        }
        catch (Exception exception)
        {
          throw;
        }
      }

      return new HttpStatusCodeResult(HttpStatusCode.OK);
    }

    /// <summary>
    /// The get course registrations.
    /// </summary>
    /// <param name="request">
    /// The request.
    /// </param>
    /// <param name="registration">
    /// The registration.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult GetCourseRegistrations([DataSourceRequest] DataSourceRequest request, int? registration)
    {
      Registration entries = this.context.Registrations.Include("Courses").FirstOrDefault(e => e.Id == registration);

      if (entries != null)
      {
        var courses = new List<RegisteredCourseViewModel>();
        foreach (Course course in entries.Courses)
        {
          courses.Add(new RegisteredCourseViewModel(course));
        }

        return this.Json(courses.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
      }

      return new HttpStatusCodeResult(HttpStatusCode.NoContent);
    }

    /// <summary>
    /// The get registrations.
    /// </summary>
    /// <param name="request">
    /// The request.
    /// </param>
    /// <param name="registrationId">
    /// The registration id.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult GetRegistrations([DataSourceRequest] DataSourceRequest request, int? registrationId)
    {
     try
        {
            List<Registration> registrations = this.context.Registrations.Include("Customer").ToList();
            var list = new List<RegistrationsViewModel>();
            foreach (var reg in registrations)
            {
                list.Add(new RegistrationsViewModel(reg));
            }
            return this.Json(list.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        catch (Exception e)
        {
            return this.Json(new {status = "error", message = e.Message, stacktrace = e.StackTrace});
        }
        
    }

    /// <summary>
    /// The index.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult Index()
    {
      return this.View();
    }

    /// <summary>
    /// The list.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [Authorize]
    public ActionResult List()
    {
      return this.View();
    }

    /// <summary>
    /// The register a.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpGet]
    public ActionResult RegisterA()
    {
      var vm = new RegisterAViewModel();
      return this.View(vm);
    }

    /// <summary>
    /// The register a.
    /// </summary>
    /// <param name="vm">
    /// The vm.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    public ActionResult RegisterA(RegisterAViewModel vm)
    {
      Registration registration = vm.Registration;

      registration.Courses.Add(this.context.Courses.FirstOrDefault(c => c.Id == vm.Course1));
      registration.Courses.Add(this.context.Courses.FirstOrDefault(c => c.Id == vm.Course2));
        registration.RegistrationDateTime = DateTime.Now;
      this.context.Registrations.Add(registration);
      this.context.SaveChanges();
      return this.RedirectToAction("RegistrationSuccessful", vm);
    }

    /// <summary>
    /// The register a 1.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpGet]
    public ActionResult RegisterA1()
    {
      var vm = new RegisterA1ViewModel();
      return this.View(vm);
    }

    [HttpPost]
    public ActionResult CreateCustomer(int id)
    {
      var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == id);

      var customer = new Customer
                       {
                         Name = registration.Name,
                         PreName = registration.PreName,
                         AddressLine = registration.AddressLine,
                         AddressLine2 = registration.AddressLine2,
                         Zip = registration.Zip,
                         City = registration.City,
                         Phone = registration.Phone,
                         EMail = registration.EMail,
                         Title = registration.Title,
                         Birtdate = registration.Birthdate
                       };
      registration.RegistrationDateTime = DateTime.Now;
      customer.Registrations.Add(registration);
      context.Customers.Add(customer);
      context.SaveChanges();
      return Json(new { state = "ok"});
    }

      
    [HttpPost]
    public ActionResult ApplyCustomer(int id, int customerId)
    {
        var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == id);
        var customer = context.Customers.Include("Registrations").FirstOrDefault(r => r.Id == customerId);
        if (customer != null)
        {
            customer.Registrations.Add(registration);
            context.SaveChanges();
            return Json(new { state = "ok" });
        }

        return new HttpStatusCodeResult(HttpStatusCode.NotFound);
      
    }

    /// <summary>
    /// The register a 1.
    /// </summary>
    /// <param name="vm">
    /// The vm.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    public ActionResult RegisterA1(RegisterA1ViewModel vm)
    {
      Registration registration = vm.Registration;

      registration.Courses.Add(this.context.Courses.FirstOrDefault(c => c.Id == vm.Course1));
      registration.Courses.Add(this.context.Courses.FirstOrDefault(c => c.Id == vm.Course2));
      registration.RegistrationDateTime = DateTime.Now;
      this.context.Registrations.Add(registration);
      this.context.SaveChanges();
      return this.RedirectToAction("RegistrationSuccessful", vm);
    }

    /// <summary>
    /// The register a with a 1.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult RegisterAWithA1()
    {
      var vm = new RegisterAWithA1ViewModel();
      return this.View(vm);
    }

    /// <summary>
    /// The register vku.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult RegisterVku()
    {
      var vm = new RegisterVkuViewModel();
      return this.View(vm);
    }

    /// <summary>
    /// The register vku.
    /// </summary>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    [HttpPost]
    public ActionResult RegisterVku(RegisterVkuViewModel vm)
    {
        Registration registration = vm.Registration;

        registration.Courses.Add(this.context.Courses.FirstOrDefault(c => c.Id == vm.Course1));
        registration.RegistrationDateTime = DateTime.Now;
        this.context.Registrations.Add(registration);
        this.context.SaveChanges();
        return this.RedirectToAction("RegistrationSuccessful", vm);
    }

    /// <summary>
    /// The registration successful.
    /// </summary>
    /// <param name="vm">
    /// The vm.
    /// </param>
    /// <returns>
    /// The <see cref="ActionResult"/>.
    /// </returns>
    public ActionResult RegistrationSuccessful(RegistrationViewModel vm)
    {
      return this.View(vm);
    }

    #endregion
  }

  /// <summary>
  ///   The register a1 view model.
  /// </summary>
  public class RegistrationViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegistrationViewModel"/> class. 
    ///   Initializes a new instance of the <see cref="RegisterViewModel"/> class.
    /// </summary>
    public RegistrationViewModel()
    {
      this.Registration = new Registration();
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the registration.
    /// </summary>
    public Registration Registration { get; set; }

    #endregion
  }

  /// <summary>
  ///   The register a1 view model.
  /// </summary>
  public class RegisterVkuViewModel : RegistrationViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterVkuViewModel"/> class.
    /// </summary>
    public RegisterVkuViewModel()
    {
      this.Registration.CourseType = "VKU";
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the course 1.
    /// </summary>
    public int Course1 { get; set; }

    #endregion
  }

  /// <summary>
  ///   The register a1 view model.
  /// </summary>
  public class RegisterA1ViewModel : RegistrationViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterA1ViewModel"/> class.
    /// </summary>
    public RegisterA1ViewModel()
    {
      this.Registration.CourseType = "A1";
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the course 1.
    /// </summary>
    public int Course1 { get; set; }

    /// <summary>
    ///   Gets or sets the course 2.
    /// </summary>
    public int Course2 { get; set; }

    #endregion
  }

  /// <summary>
  ///   The register a1 view model.
  /// </summary>
  public class RegisterAViewModel : RegistrationViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAViewModel"/> class.
    /// </summary>
    public RegisterAViewModel()
    {
      this.Registration.CourseType = "A";
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the course 1.
    /// </summary>
    public int Course1 { get; set; }

    /// <summary>
    ///   Gets or sets the course 2.
    /// </summary>
    public int Course2 { get; set; }

    /// <summary>
    ///   Gets or sets the course 3.
    /// </summary>
    public int Course3 { get; set; }

    #endregion
  }

  /// <summary>
  ///   The register a1 view model.
  /// </summary>
  public class RegisterAWithA1ViewModel : RegistrationViewModel
  {
    #region Constructors and Destructors

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterAWithA1ViewModel"/> class.
    /// </summary>
    public RegisterAWithA1ViewModel()
    {
      this.Registration.CourseType = "A(A1)";
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the course 1.
    /// </summary>
    public int Course1 { get; set; }

    /// <summary>
    ///   Gets or sets the course 2.
    /// </summary>
    public int Course2 { get; set; }

    #endregion
  }
}