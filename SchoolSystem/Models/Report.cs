using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime TimeInterval { get; set; }

    }
}
