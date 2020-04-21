using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
	public class ActualsSummaryReportModel
	{
		public int EmployeeID { get; set; }
		public string EmployeeFirstname { get; set; }
		public string EmployeeMiddleInitial { get; set; }
		public string EmployeeLastName { get; set; }
		public string PerformanceRating { get; set; }
		public string CurrentPosition { get; set; }
		public string PositionAfterReview { get; set; }
		public double Salary { get; set; }
		public int SupervisorID { get; set; }
		public string DateOfReview { get; set; }
		public int YearForReport { get; set; }

	}
}
