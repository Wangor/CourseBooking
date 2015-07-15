using CourseBooking.Models;

namespace CourseBooking.QueryServices
{
    using System.Collections.Generic;
    using System.Configuration;

    /// <summary>
    /// The course query service.
    /// </summary>
    public class CourseQueryService : ICourseQueryService
    {
        private string connectionString;

        public CourseQueryService()
        {
            connectionString = ConfigurationManager.AppSettings["CourseConnectionString"];
        }

        public IEnumerable<Course> GetAll()
        {
            return null;
        }

        public IEnumerable<Course> GetAllActual()
        {
            return null;
        }

        public IEnumerable<Course> GetAllByType(int templateId)
        {
            return null;
        }

        public IEnumerable<Course> GetAllActualByType(int templateId)
        {
            return null;
        }
    }
}