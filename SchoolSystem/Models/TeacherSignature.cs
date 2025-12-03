using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class TeacherSignature
    {
        public int TeacherSignatureId { get; set; }
        public int TeacherReportId { get; set; }
        public int FkReportId { get; set; }
        public int FkTeacherId { get; set; }
        public string Grade { get; set; }
        public DateTime GradingDate { get; set; }


    }
}
