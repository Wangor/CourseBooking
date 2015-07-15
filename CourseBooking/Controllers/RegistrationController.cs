using System.Linq;
using System.Web.Mvc;
using CourseBooking.Models;

namespace CourseBooking.Controllers
{
    public class RegistrationController : Controller
    {
      private CourseContext context;

      public RegistrationController()
      {
        this.context = new CourseContext();
      }

      public ActionResult RegisterVku()
      {
        var vm = new RegisterVkuViewModel();
        return this.View(vm);
      }

      public ActionResult RegisterA1()
      {
        var vm = new RegisterA1ViewModel();
        return this.View(vm);
      }

      public ActionResult RegisterA()
      {
        var vm = new RegisterAViewModel();
        return this.View(vm);
      }

      public ActionResult RegisterAWithA1()
      {
        var vm = new RegisterAWithA1ViewModel();
        return this.View(vm);
      }

      public ActionResult List()
      {
        return View();
      }
    }

  /// <summary>
  /// The register a1 view model.
  /// </summary>
  public class RegistrationViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterViewModel"/> class.
    /// </summary>
    public RegistrationViewModel()
    {
      Registration = new Registration();
    }

    /// <summary>
    /// Gets or sets the registration.
    /// </summary>
    public Registration Registration { get; set; }
  }

  /// <summary>
  /// The register a1 view model.
  /// </summary>
  public class RegisterVkuViewModel : RegistrationViewModel
  {
    /// <summary>
    /// Gets or sets the course 1.
    /// </summary>
    public Course Course1 { get; set; }
  }

  /// <summary>
  /// The register a1 view model.
  /// </summary>
  public class RegisterA1ViewModel : RegistrationViewModel
  {
    /// <summary>
    /// Gets or sets the course 1.
    /// </summary>
    public Course Course1 { get; set; }

    /// <summary>
    /// Gets or sets the course 2.
    /// </summary>
    public Course Course2 { get; set; }
  }

  /// <summary>
  /// The register a1 view model.
  /// </summary>
  public class RegisterAViewModel : RegistrationViewModel
  {
    /// <summary>
    /// Gets or sets the course 1.
    /// </summary>
    public Course Course1 { get; set; }

    /// <summary>
    /// Gets or sets the course 2.
    /// </summary>
    public Course Course2 { get; set; }

    /// <summary>
    /// Gets or sets the course 3.
    /// </summary>
    public Course Course3 { get; set; }
  }

  /// <summary>
  /// The register a1 view model.
  /// </summary>
  public class RegisterAWithA1ViewModel : RegistrationViewModel
  {
    /// <summary>
    /// Gets or sets the course 1.
    /// </summary>
    public Course Course1 { get; set; }

    /// <summary>
    /// Gets or sets the course 2.
    /// </summary>
    public Course Course2 { get; set; }
  }
}