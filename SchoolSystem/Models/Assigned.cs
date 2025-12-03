using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class Assigned
    {
        [Key ]
        public int AssignedId { get; set; }
        public int FkStudentId { get; set; }

        [ForeignKey(nameof(FkStudentId))]
        public virtual Student Student {get; set; }
        public int FkClassroomId { get; set; }
        [ForeignKey(nameof(FkClassroomId))]
        public virtual Classroom Classroom { get; set; }
    }
}
