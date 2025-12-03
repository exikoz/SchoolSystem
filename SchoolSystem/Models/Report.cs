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
        public DateTime IssuedDate { get; set; }
        public DateTime TimeInterval { get; set; }

    }
}
