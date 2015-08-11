// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerViewModel.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the CustomerViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using CourseBooking.Models;

namespace CourseBooking.ViewModels
{
    /// <summary>
    ///     The customer view model.
    /// </summary>
    public class CustomerViewModel
    {
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
        /// Gets or sets the zip.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the e mail.
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// Gets or sets the birthdate.
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the lfa end date time.
        /// </summary>
        public DateTime? LfaEndDateTime { get; set; }

        public string RegRefNr { get; set; }

        /// <summary>
        /// The apply customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        public void ApplyCustomer(Customer customer)
        {
            this.Name = customer.Name;
            this.PreName = customer.PreName;
            this.AddressLine = customer.AddressLine;
            this.AddressLine2 = customer.AddressLine2;
            this.Zip = customer.Zip;
            this.City = customer.City;
            this.Phone = customer.Phone;
            this.EMail = customer.EMail;
            this.Birthdate = customer.Birtdate;
        } 
    }
}