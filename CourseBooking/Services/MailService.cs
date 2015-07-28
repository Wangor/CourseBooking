using System.Linq;
using System.Net;
using System.Net.Mail;
using CourseBooking.Models;
using SendGrid;

namespace CourseBooking.Services
{
    public class MailService
    {
        public static void ConfirmRegistration(int registrationId)
        {
            var context = new CourseContext();
            var registration = context.Registrations.Include("Courses").FirstOrDefault(r => r.Id == registrationId);

            if (registration != null)
            {

                SendGridMessage myMessage = new SendGridMessage();
                myMessage.AddTo(registration.EMail);
                myMessage.From = new MailAddress("gerry.gruetter@gmx.ch", "Fahrschule Grütter-Stooss");
                myMessage.Subject = "Bestätigung Deiner Anmeldung";
                myMessage.Text = "Für den Kurs";

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
    }
}