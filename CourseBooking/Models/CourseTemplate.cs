// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseTemplate.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CourseTemplate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseBooking.Models
{
  /// <summary>
    /// The course template.
    /// </summary>
    [Table("CourseTemplate")]
    public class CourseTemplate
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Display(Name = "Name des Kurses")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of hours.
        /// </summary>
        [Display(Name = "Dauer (Stunden)")]
        public int NumberOfHours { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Display(Name = "Standard Ort")]
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the max participants.
        /// </summary>
        [Display(Name = "Maximale Teilnehmerzahl")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Display(Name = "Standard Preis")]
        public string Price { get; set; }
    }
}