using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class Enrolls
    {
        public int EnrollsId { get; set; }
        public int FkCourseId { get; set; }
        public int FkStudentId { get; set; }

    }
}
