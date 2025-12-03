using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class Classroom
    {
        [Key]
        public int ClassroomId {get; set;}
        public int Capacity { get; set; }

        public virtual ICollection<Assigned> Assigneds { get; set; } = new List<Assigned>();
        public virtual ICollection<ClassroomTeacher> ClassroomTeachers { get; set; } = new List<ClassroomTeacher>();
    }
}
