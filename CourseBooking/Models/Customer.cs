// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the Customer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace CourseBooking.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;

  /// <summary>
  ///   The customer.
  /// </summary>
  public class Customer
  {
    public Customer()
    {
      this.Registrations = new List<Registration>();
    }
    #region Public Properties

    /// <summary>
    ///   Gets or sets the address line.
    /// </summary>
    public string AddressLine { get; set; }

    /// <summary>
    ///   Gets or sets the address line 2.
    /// </summary>
    public string AddressLine2 { get; set; }

    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    ///   Gets or sets the e mail.
    /// </summary>
    public string EMail { get; set; }

    /// <summary>
    ///   Gets or sets the id.
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the phone.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    ///   Gets or sets the pre name.
    /// </summary>
    public string PreName { get; set; }

    /// <summary>
    ///   Gets or sets the courses.
    /// </summary>
    public virtual ICollection<Registration> Registrations { get; set; }

    /// <summary>
    ///   Gets or sets the title.
    /// </summary>
    public string Title { get; set; }

    public DateTime? Birtdate { get; set; }

    /// <summary>
    /// Gets or sets the zip.
    /// </summary>
    public string Zip { get; set; }

    #endregion
  }
}