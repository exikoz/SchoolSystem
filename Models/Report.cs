using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Period { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public string AssociatedTeacher { get; set; }
        public DateTime GradingDate { get; set; }
        public int FkStudentId { get; set; }

    }
}
