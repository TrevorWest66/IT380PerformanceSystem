using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
	public class PredictionSummaryReportModel
	{
		public int EmployeeID { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; } 
		public string ProjectedPR { get; set; }
		public string CurrentPosition { get; set; }
		public bool ProjectedPosition { get; set; }
		public string CurrentSalary { get; set; }
		public string SalaryIncrease { get; set; }
		public string Supervisor { get; set; }

		//derived attributes
		public string NewSalary;
		public bool PositionChange;

	}
}
