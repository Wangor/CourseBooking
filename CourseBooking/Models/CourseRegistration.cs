using System.ComponentModel.DataAnnotations;

namespace CourseBooking.Models
{
  public class CourseRegistration
  {
    [Key]
    public int Id { get; set; }

    public Course Course { get; set; }
    public Registration Registration { get; set; }
  }
}