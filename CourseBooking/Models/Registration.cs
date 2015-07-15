// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Registration.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the Registration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace CourseBooking.Models
{
  /// <summary>
    /// The registration.
    /// </summary>
    public class Registration
    {
        public Registration()
        {
          Courses = new List<CourseRegistration>();
        }
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pre name.
        /// </summary>
        public string PreName { get; set; }

        /// <summary>
        /// Gets or sets the address line.
        /// </summary>
        public string AddressLine { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        public string EMail { get; set; }

        public List<CourseRegistration> Courses { get; set; }
    }
}