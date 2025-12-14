using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    // This class is used to mape to the SQL View_StudentGradeDetails
    public class StudentGradeView
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty ;
        public string PersonalNumber {  get; set; } = string.Empty ;
        public string CourseName {  get; set; } = string.Empty ;
        public string GradeValue {  get; set; } = string.Empty ;
        public DateTime GradeDate { get; set; }
        public string TeacherName {  get; set; } = string.Empty ;
    }
}
