// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
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
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Registrations = new List<Registration>();
        }

        #region Public Properties

        /// <summary>
        ///   Gets or sets the address line.
        /// </summary>
        [Display(Name = "Strasse")]
        public string AddressLine { get; set; }

        /// <summary>
        ///   Gets or sets the address line 2.
        /// </summary>
        [Display(Name = "Adresszusatz")]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Display(Name = "Ort")]
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
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        ///   Gets or sets the phone.
        /// </summary>
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        /// <summary>
        ///   Gets or sets the pre name.
        /// </summary>
        [Display(Name = "Vorname")]
        public string PreName { get; set; }

        /// <summary>
        ///   Gets or sets the courses.
        /// </summary>
        [Display(Name = "Anmeldungen")]
        public ICollection<Registration> Registrations { get; set; }

        /// <summary>
        ///   Gets or sets the title.
        /// </summary>
        [Display(Name = "Titel")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the birtdate.
        /// </summary>
        [Display(Name = "Geburtsdatum")]
        public DateTime? Birtdate { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [Display(Name = "PLZ")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        [Display(Name = "Bemerkungen")]
        public string Remarks { get; set; }

        /// <summary>
        /// Gets or sets the additional information.
        /// </summary>
        [Display(Name = "zusätzliche Informationen")]
        public string AdditionalInformation { get; set; }

        #endregion
    }
}