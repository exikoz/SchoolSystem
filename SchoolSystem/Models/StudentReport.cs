using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class StudentReport
    {
        [Key]
        public int StudentReportId { get; set; }
        public int FkReportId { get; set; }
        [ForeignKey(nameof(FkReportId))]
        public virtual Report Report { get; set; }
        public int FkStudentId { get; set; }
        [ForeignKey(nameof(FkStudentId))]
        public virtual Student Student { get; set; }
    }
}
