// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MailService.cs" company="Bärtschi Software">
//   (c) 2015
// </copyright>
// <summary>
//   Defines the MailService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace CourseBooking.Services
{
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using Models;
    using SendGrid;

    public class MailService
    {
        public static void ConfirmRegistration(int registrationId)
        {
            var context = new CourseContext();
            var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == registrationId);

            if (registration != null)
            {

                var myMessage = new SendGridMessage();
                myMessage.AddTo(registration.EMail);
                myMessage.From = new MailAddress("gerry.gruetter@gmx.ch", "Fahrschule Grütter-Stooss");
                myMessage.Subject = "Bestätigung Deiner Anmeldung";

                if (registration.Courses.Count == 1)
                {
                    var course = registration.Courses.ElementAt(0);
                    myMessage.Text = string.Format("Für den Kurs {0} am {1}", course.Name, course.StartDateTime);
                }

                if (registration.Courses.Count > 1)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Für die Kurse:");
                    foreach (var course in registration.Courses)
                    {
                        sb.AppendLine(string.Format("Für den Kurs {0} am {1}", course.Name, course.StartDateTime));

                        myMessage.Text = sb.ToString();
                    }
                }

                // Create credentials, specifying your user name and password.
                var credentials = new NetworkCredential("7c64bd24-10db-495c-ad66-af83bb44681f@apphb.com",
                    "7c64bd24-10db-495c-ad66-af83bb44681f@apphb.com");

                // Create an Web transport for sending email, using credentials...
                //var transportWeb = new Web(credentials);

                // ...OR create a Web transport, using API Key (preferred)
                var transportWeb = new Web("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");

                // Send the email.
                transportWeb.DeliverAsync(myMessage);
            }
        }

        /// <summary>
        /// The confirm registration direct.
        /// </summary>
        /// <param name="registrationId">
        /// The registration id.
        /// </param>
        public static void ConfirmRegistrationDirect(int registrationId)
        {
            var context = new CourseContext();
            var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == registrationId);

            if (registration != null)
            {

                var myMessage = new SendGridMessage();
                myMessage.AddTo(registration.EMail);
                myMessage.From = new MailAddress("gerry.gruetter@gmx.ch", "Fahrschule Grütter-Stooss");
                myMessage.Subject = "Anmeldung erhalten";

                if (registration.Courses.Count == 1)
                {
                    var course = registration.Courses.ElementAt(0);
                    myMessage.Text = string.Format("Für den Kurs {0} am {1}\n", course.Name, course.StartDateTime);
                }

                if (registration.Courses.Count > 1)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Für die Kurse:");
                    foreach (var course in registration.Courses)
                    {
                        sb.AppendLine(string.Format("Für den Kurs {0} am {1}\n", course.Name, course.StartDateTime));

                        myMessage.Text = sb.ToString();
                    }
                }

                var transportWeb = new Web("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");

                // Send the email.
                transportWeb.DeliverAsync(myMessage);
            }
        }

        /// <summary>
        /// The confirm registration inform backoffice.
        /// </summary>
        /// <param name="registrationId">
        /// The registration id.
        /// </param>
        public static void ConfirmRegistrationInformBackoffice(int registrationId)
        {
            var context = new CourseContext();
            var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == registrationId);

            if (registration != null)
            {

                var myMessage = new SendGridMessage();
                myMessage.AddTo("matt@matt-b.ch");
                myMessage.AddTo("gerry.gruetter@gmx.ch");
                myMessage.From = new MailAddress("gerry.gruetter@gmx.ch", "Fahrschule Grütter-Stooss");
                myMessage.Subject = string.Format("Anmeldung erhalten von {0} {1}\n", registration.Name, registration.PreName);

                if (registration.Courses.Count == 1)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(string.Format("{0} {1}\n", registration.Name, registration.PreName));
                    sb.AppendLine(string.Format("{0}\n", registration.AddressLine));
                    sb.AppendLine(string.Format("{0} {1}\n", registration.Zip, registration.City));
                    sb.AppendLine(string.Format("{0}\n", registration.Phone));

                    var course = registration.Courses.ElementAt(0);
                    sb.AppendLine(string.Format("Für den Kurs {0} am {1}\n", course.Name, course.StartDateTime));
                    
                    myMessage.Text = sb.ToString();
                }

                if (registration.Courses.Count > 1)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine(string.Format("{0} {1}\n", registration.Name, registration.PreName));
                    sb.AppendLine(string.Format("{0}\n", registration.AddressLine));
                    sb.AppendLine(string.Format("{0} {1}\n", registration.Zip, registration.City));
                    sb.AppendLine(string.Format("{0}\n", registration.Phone));

                    sb.AppendLine("Für die Kurse:\n");
                    foreach (var course in registration.Courses)
                    {
                        sb.AppendLine(string.Format("Für den Kurs {0} am {1}\n", course.Name, course.StartDateTime));

                        myMessage.Text = sb.ToString();
                    }
                }

                var transportWeb = new Web("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");

                // Send the email.
                transportWeb.DeliverAsync(myMessage);
            }
        }
    }
}