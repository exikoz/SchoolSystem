using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class StudentReport
    {
        public int StudentReportId { get; set; }
        public int FkReportId { get; set; }
        public int FkStudentId { get; set; }
    }
}
