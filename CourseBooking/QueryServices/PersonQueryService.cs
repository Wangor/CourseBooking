namespace CourseBooking.QueryServices
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;

    using CourseBooking.Models;

    using Microsoft.Owin.Security.Provider;

    public class PersonQueryService : IPersonQueryService
    {
        private string connectionString;

        public PersonQueryService()
        {
            connectionString = ConfigurationManager.AppSettings["CourseConnectionString"];
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return null;
        }

        public IEnumerable<ApplicationUser> GetAllByCourse(int courseId)
        {
           return null;
        }

        public IEnumerable<ApplicationUser> GetAllByCourseTemplate(int courseId)
        {
            return null;
        }


    }
}