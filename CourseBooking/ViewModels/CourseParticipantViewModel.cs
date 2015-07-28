// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseParticipantViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CourseParticipantViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.ViewModels
{
  using CourseBooking.Models;

  /// <summary>
  /// The course participant view model.
  /// </summary>
  public class CourseParticipantViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CourseParticipantViewModel"/> class.
    /// </summary>
    /// <param name="registration">
    /// The registration.
    /// </param>
    public CourseParticipantViewModel(Registration registration)
    {
      this.Name = registration.Name;
      this.PreName = registration.PreName;
      City = registration.City;
      Phone = registration.Phone;
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the pre name.
    /// </summary>
    public string PreName { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the phone.
    /// </summary>
    public string Phone { get; set; }
  }
}