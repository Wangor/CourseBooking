// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The course view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.ViewModels
{
  using System;

  /// <summary>
  /// The course view model.
  /// </summary>
  public class CourseViewModel
  {
    #region Public Properties

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the price.
    /// </summary>
    public string Price { get; set; }

    /// <summary>
    /// Gets or sets the start date time.
    /// </summary>
    public DateTime? StartDateTime { get; set; }

    #endregion
  }
}