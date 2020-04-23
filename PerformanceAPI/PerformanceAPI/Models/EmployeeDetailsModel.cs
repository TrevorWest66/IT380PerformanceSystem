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
		public string SalaryFlag { get; set; }
		public string HireDate { get; set; }
		public string SupervisorFirstName { get; set; }
		public string SupervisorLastName { get; set; }
		public string LastReviewDate { get; set; }
		public string ProjectedPosition { get; set; }
		public string DateOfProjection { get; set; }
		public string ProjectedSalaryIncrease { get; set; }
		public string ProjectedRating { get; set; }

	}
}
