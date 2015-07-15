using CourseBooking.Models;

namespace CourseBooking.QueryServices
{
    using System.Collections.Generic;

    public interface ICourseQueryService
    {
        IEnumerable<Course> GetAll();

        IEnumerable<Course> GetAllActual();

        IEnumerable<Course> GetAllByType(int templateId);

        IEnumerable<Course> GetAllActualByType(int templateId);
    }
}