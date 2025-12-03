using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Schedule { get; set; } = string.Empty;
        public  DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }

        public virtual ICollection<Enrolls> Enrolls { get; set; } = new List<Enrolls>();
    }
}
