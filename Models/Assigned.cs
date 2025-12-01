using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class Assigned
    {
        public int ClassroomStudentId { get; set; }
        public int FkStudentId { get; set; }
        public int FkClassroomId { get; set; }
    }
}
