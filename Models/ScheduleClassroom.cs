using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class ScheduleClassroom
    {
        public int ScheduleClassroomId { get; set; }
        public int FkClassroomTeacherId { get; set; }
        public DateTime TimeInterval { get; set; }
    }
}
