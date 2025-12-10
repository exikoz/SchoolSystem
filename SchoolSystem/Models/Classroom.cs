using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    [Index(nameof(ClassroomName), IsUnique = true)]
    public class Classroom
    {
        [Key]
        public int ClassroomId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClassroomName { get; set; } = string.Empty;

        public int Capacity { get; set; }

        // Navigation Properties
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}