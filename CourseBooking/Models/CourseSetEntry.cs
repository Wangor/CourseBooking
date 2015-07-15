// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseSetEntry.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The course set entry.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace CourseBooking.Models
{
  /// <summary>
    /// The course set entry.
    /// </summary>
    [Table("CourseSetEntry")]
    public class CourseSetEntry
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the sorting.
        /// </summary>
        public int Sorting { get; set; }

        /// <summary>
        /// Gets or sets the course template.
        /// </summary>
        public CourseTemplate CourseTemplate { get; set; }

        /// <summary>
        /// Gets or sets the course set.
        /// </summary>
        [ScriptIgnore]
        public CourseSet CourseSet { get; set; }

        [NotMapped]
        public string CourseSetId { get; set; }
    }
}