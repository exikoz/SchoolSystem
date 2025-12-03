using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SchoolSystemDB.Models
{
    public class ScheduleClassroom
    {
        [Key]
        public int ScheduleClassroomId { get; set; }
        public int FkClassroomTeacherId { get; set; }
        [ForeignKey(nameof(FkClassroomTeacherId))]
        public ClassroomTeacher ClassroomTeacher { get; set; }
        public DateTime TimeInterval { get; set; }
    }
}
