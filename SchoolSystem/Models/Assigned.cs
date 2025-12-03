using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class Assigned
    {
        [Key ]
        public int AssignedId { get; set; }
        public int FkStudentId { get; set; }
        public int FkClassroomId { get; set; }
    }
}
