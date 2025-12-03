using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystemDB.Models
{
    public class Course
    {
        //public string Name { get; set; }
        //public bool Active { get; set; }
        public int CourseId { get; set; }
        public string Schedule { get; set; }
        public  DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
    }
}
