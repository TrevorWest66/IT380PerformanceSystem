using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace PerformanceAPI.Models
{
	public static class CurrentUserModel
	{
		public static int CurrentEmployeeID = 100002;
		public static int CurrentBudge = 1100000;
		public static int CurrentBudgetUsed;
		public static int NumberOfEmployeesWithProjections;
		public static int NumberOfEmployeesWithActuals;
		public static int NumberOfEmployees = 15;
		public static int[] AcceptableSupervisorIds = { 100004, 100005 };
		public static int OverBudgetAmount;

		//don't worry about this it is set in the reports page
		public static bool CurrentReportYear;

		public static string GetFormattedOverBudgetAmount()
		{
			string formattedAmount = "$" + Math.Abs(OverBudgetAmount).ToString("N");
			return formattedAmount;
		}
	}


}
