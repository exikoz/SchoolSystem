using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class TeacherSignature
    {
        public int TeacherReportId { get; set; }
        public int FkReportId { get; set; }
        public int FkTeacherId { get; set; }

    }
}
