using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class EmployeeListProjectionsModel
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // from form
        public string projectedReview { get; set; }
        public string projectedPosition { get; set; }
        public string projectedSalaryIncrease { get; set; }
        public string comments { get; set; }
    }
}
