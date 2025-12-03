using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystemDB.Models
{
    public class Enrolls
    {
        [Key]
        public int EnrollsId { get; set; }
        public int FkCourseId { get; set; }
        [ForeignKey(nameof(FkCourseId))]
        public virtual Course Course { get; set; }
        public int FkStudentId { get; set; }
        [ForeignKey(nameof(FkStudentId))]
        public virtual Student Student { get; set; }

    }
}
