using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class ClassroomTeacher
    {
        public int ClassroomTeacherId { get; set; }/* <- Added ClassRoomTeacherId to avoid composite keys and make this entity easier to use in EF Core.
                                                      The table contains its own data (Schedule), so it behaves like a full entity rather than a pure join table.*/
        public int FkTeacherId { get; set; }
        public int FkClassroomId { get; set; }

    }
}
