// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseSet.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CourseSet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// The course set.
    /// </summary>
    [Table("CourseSet")]
    public class CourseSet
    {
      public CourseSet()
      {
        if (Entries == null)
        {
          Entries = new List<CourseSetEntry>();
        }
      }
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        public List<CourseSetEntry> Entries { get; set; }
    }
}