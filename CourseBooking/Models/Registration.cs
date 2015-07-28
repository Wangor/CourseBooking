// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Registration.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the Registration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CourseBooking.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  /// <summary>
  ///   The registration.
  /// </summary>
  public class Registration
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="Registration" /> class.
    /// </summary>
    public Registration()
    {
      this.Courses = new List<Course>();
      this.Confirmed = false;
    }

    #endregion

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
    public ICollection<Course> Courses { get; set; }

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

    #endregion
  }
}