using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class TeacherSignature
    {
        [Key]
        public int TeacherSignatureId { get; set; }
        public int FkReportId { get; set; }
        [ForeignKey(nameof(FkReportId))]
        public virtual Report Report { get; set; }
        public int FkTeacherId { get; set; }
        [ForeignKey(nameof(FkTeacherId))]
        public virtual Teacher Teacher { get; set; }
        public string Grade { get; set; } = string.Empty;
        public DateTime GradingDate { get; set; }


    }
}
