using System.ComponentModel.DataAnnotations;
namespace SchoolSystemDB.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty; // avoid null warnings
        public string TeachingSubject { get; set; } = string.Empty;

        // Navigation Property
        public virtual ICollection<ClassroomTeacher> ClassroomTeachers { get; set; } = new List<ClassroomTeacher>();
    }
}
