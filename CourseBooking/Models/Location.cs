using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseBooking.Models
{
  [Table("Location")]
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name des Ortes")]
        public string Name { get; set; }

        [Display(Name = "Strasse")]
        public string Street { get; set; }

        [Display(Name = "PLZ")]
        public string Zip { get; set; }

        [Display(Name = "Ort")]
        public string City { get; set; }
    }
}