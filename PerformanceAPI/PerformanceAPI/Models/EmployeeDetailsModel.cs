using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class EmployeeDetailsModel
    {
		public int EmployeeID { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Posistion { get; set; }
		public string Team { get; set; }
		public string Department { get; set; }
		public double CurrentSalary { get; set; }
		public Boolean SalaryFlag { get; set; }
		public string HireDate { get; set; }
		public string SupervisorFirstName { get; set; }
		public string SupervisorLastName { get; set; }
	}
}
