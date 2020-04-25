using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class ProjectionsModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentPosition { get; set; }
        public string SalaryFlag { get; set; }
        public string EmployeeCurrentSalary { get; set; }
        public int SupervisorID { get; set; }


    }
}
