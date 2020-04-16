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
		public string ProjectedPosition { get; set; }
		public double CurrentSalary { get; set; }
		public double SalaryIncrease { get; set; }
		public int Supervisor { get; set; }
		public string DateOfProjection { get; set; }

		//derived attributes
		public string NewSalary;
		public bool PositionChange;

	}
}
