// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Course.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the Course type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;

  /// <summary>
    /// The course.
    /// </summary>
    [Table("Course")]
    public class Course
    {
      public Course()
      {
          StartDateTime = DateTime.UtcNow;
      }
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
        /// Gets or sets the remark.
        /// </summary>
        [Display(Name = "Bemerkung")]
        public string Remark { get; set; }

        /// <summary>
        /// Gets or sets the message field.
        /// </summary>
        [Display(Name = "Mitteilung")]
        public int MessageField { get; set; }

        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        [Display(Name = "Beginn")]
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Gets or sets the course template.
        /// </summary>
        [Display(Name = "Kursvorlage")]
        public int CourseTemplateId { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Display(Name = "Ort")]
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the max participants.
        /// </summary>
        [Display(Name = "Maximale Teilnehmerzahl")]
        public int MaxParticipants { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Display(Name = "Kosten")]
        public string Price { get; set; }

        /// <summary>
        ///   Gets or sets the registrations.
        /// </summary>
        public ICollection<Registration> Registrations { get; set; }
    }
}