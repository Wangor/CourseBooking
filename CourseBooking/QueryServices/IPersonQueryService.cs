namespace CourseBooking.QueryServices
{
    using System.Collections.Generic;

    using CourseBooking.Models;

    public interface IPersonQueryService
    {
        IEnumerable<ApplicationUser> GetAll();

        IEnumerable<ApplicationUser> GetAllByCourse(int courseId);

        IEnumerable<ApplicationUser> GetAllByCourseTemplate(int courseId);
    }
}