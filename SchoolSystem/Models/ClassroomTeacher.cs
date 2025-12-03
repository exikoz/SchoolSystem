using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class ClassroomTeacher
    {
        [Key]
        public int ClassroomTeacherId { get; set; }
        public int FkTeacherId { get; set; }
        [ForeignKey(nameof(FkTeacherId))]
        public virtual Teacher Teacher { get; set; }
        public int FkClassroomId { get; set; }
        [ForeignKey(nameof(FkClassroomId))]
        public virtual Classroom Classroom { get; set; }

}
}
