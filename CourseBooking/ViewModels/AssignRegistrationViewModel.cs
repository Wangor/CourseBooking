// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssignRegistrationViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the AssignRegistrationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  using CourseBooking.Models;

  /// <summary>
  /// The assign registration view model.
  /// </summary>
  public class AssignRegistrationViewModel
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AssignRegistrationViewModel"/> class.
    /// </summary>
    /// <param name="registration">
    /// The registration.
    /// </param>
    public AssignRegistrationViewModel(Registration registration)
    {
      this.Id = registration.Id;
      this.Name = registration.Name;
      this.PreName = registration.PreName;
      this.AddressLine = registration.AddressLine;
      this.AddressLine2 = registration.AddressLine2;
      this.Zip = registration.Zip;
      this.City = registration.City;
      this.Phone = registration.Phone;
      this.EMail = registration.EMail;
      this.Courses = new List<AssignRegistrationCourseViewModel>();

      foreach (var course in registration.Courses)
      {
        this.Courses.Add(new AssignRegistrationCourseViewModel { Name = course.Name, StartDateTime = course.StartDateTime, Price = course.Price });
      }
    }

    #region Public Properties

    /// <summary>
    ///   Gets or sets the address line.
    /// </summary>
    [Required]
    [Display(Name = "Strasse")]
    public string AddressLine { get; set; }

    /// <summary>
    ///   Gets or sets the address line 2.
    /// </summary>
    [Display(Name = "Adresszusatz")]
    public string AddressLine2 { get; set; }

    /// <summary>
    ///   Gets or sets the city.
    /// </summary>
    [Required]
    [Display(Name = "Ort")]
    public string City { get; set; }

    /// <summary>
    ///   Gets or sets a value indicating whether confirmed.
    /// </summary>
    public bool Confirmed { get; set; }

    /// <summary>
    ///   Gets or sets the course type.
    /// </summary>
    public string CourseType { get; set; }

    /// <summary>
    ///   Gets or sets the courses.
    /// </summary>
    public ICollection<AssignRegistrationCourseViewModel> Courses { get; set; }

    /// <summary>
    ///   Gets or sets the e mail.
    /// </summary>
    [Required]
    [Display(Name = "E-Mail")]
    public string EMail { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    [Required]
    [Display(Name = "Nachname")]
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the phone.
    /// </summary>
    [Required]
    [Display(Name = "Telefonnummer")]
    public string Phone { get; set; }

    /// <summary>
    ///   Gets or sets the pre name.
    /// </summary>
    [Required]
    [Display(Name = "Vorname")]
    public string PreName { get; set; }

    /// <summary>
    ///   Gets or sets the title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///   Gets or sets the zip.
    /// </summary>
    [Required]
    [Display(Name = "PLZ")]
    public string Zip { get; set; }

    /// <summary>
    ///   Gets or sets the birthdate.
    /// </summary>
    [Required]
    [Display(Name = "Geburtsdatum")]
    public DateTime? Birthdate { get; set; }

    /// <summary>
    ///   Gets or sets the LfaEndDateTime.
    /// </summary>
    [Required]
    [Display(Name = "LFA-Ablauf")]
    public DateTime? LfaEndDateTime { get; set; }

    /// <summary>
    ///   Gets or sets the regRefNr.
    /// </summary>
    [Display(Name = "Reg / Ref Nr.")]
    public string RegRefNr { get; set; }

    /// <summary>
    ///   Gets or sets the remark.
    /// </summary>
    [Display(Name = "Bemerkung")]
    public string Remark { get; set; }

    /// <summary>
    /// Gets or sets the customer id.
    /// </summary>
    public int CustomerId { get; set; }

    #endregion


  }
}