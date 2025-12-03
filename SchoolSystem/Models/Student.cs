using System.ComponentModel.DataAnnotations;

namespace SchoolSystemDB.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty; // avoid null warnings

        //(One-to-Many relationships) navigation properties
        public virtual ICollection<Assigned> Assigneds { get; set; } = new List<Assigned>();
        public virtual ICollection<Enrolls> Enrolls { get; set; } = new List<Enrolls>();

    }
}
