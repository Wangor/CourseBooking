// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CourseViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CourseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using NodaTime;

namespace CourseBooking.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Models;

    /// <summary>
    /// The course view model.
    /// </summary>
    public class CourseViewModel
    {
        // Timezone data provider (inject with DI)
        IDateTimeZoneProvider timeZoneProvider = DateTimeZoneProviders.Tzdb;

        public CourseViewModel(Course course)
        {
            var local = timeZoneProvider["Europe/Zurich"];


            this.Id = course.Id;
            this.Name = course.Name;
            this.Remark = course.Remark;
            this.CourseTemplateId = course.CourseTemplateId;
            this.LocationId = course.LocationId;
            this.StartDateTime = local.AtStrictly(LocalDateTime.FromDateTime(course.StartDateTime)).ToDateTimeUnspecified();
            this.MaxParticipants = course.MaxParticipants;
            this.Price = course.Price;
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