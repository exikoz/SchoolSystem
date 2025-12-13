using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Models
{
    // This class is used to map the result Stored Procedure of the GetGradeDistribution

    public class GradeStatistic
    {
        public string GradeValue { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
