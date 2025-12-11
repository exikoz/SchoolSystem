using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Classroom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Capacity { get; set; }

        // Navigation Properties
        public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}