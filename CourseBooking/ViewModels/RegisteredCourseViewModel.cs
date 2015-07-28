namespace CourseBooking.ViewModels
{
  using System;

  using CourseBooking.Models;

  public class RegisteredCourseViewModel
  {
    public RegisteredCourseViewModel(Course course)
    {
      this.Name = course.Name;
      this.Price = course.Price;
      this.StartDateTime = course.StartDateTime;
    }
    public string  Name { get; set; }

    public DateTime? StartDateTime { get; set; }

    public string Price { get; set; }
  }
}