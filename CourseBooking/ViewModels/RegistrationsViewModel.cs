﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationsViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   The registration view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CourseBooking.ViewModels
{
    using System;
    using Models;

    /// <summary>
    ///     The registration view model.
    /// </summary>
    public class RegistrationsViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsViewModel"/> class.
        /// </summary>
        public RegistrationsViewModel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationsViewModel"/> class.
        /// </summary>
        /// <param name="registration">
        /// The registration.
        /// </param>
        public RegistrationsViewModel(Registration registration)
        {
            this.Id = registration.Id;
            this.Name = registration.Name;
            this.PreName = registration.PreName;
            this.City = registration.City;
            this.CourseType = registration.CourseType;
            this.IsAssigned = registration.Customer != null;
            this.Confirmed = registration.Confirmed;
            this.RegistrationDateTime = registration.RegistrationDateTime;
            this.Phone = registration.Phone;
            this.EMail = registration.EMail;
        }

        /// <summary>
        /// Gets or sets the registration date time.
        /// </summary>
        public DateTime RegistrationDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether confirmed.
        /// </summary>
        public bool Confirmed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is assigned.
        /// </summary>
        public bool IsAssigned { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the pre name.
        /// </summary>
        public string PreName { get; set; }

        /// <summary>
        /// Gets or sets the course type.
        /// </summary>
        public string CourseType { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        public string EMail { get; set; }
    }
}