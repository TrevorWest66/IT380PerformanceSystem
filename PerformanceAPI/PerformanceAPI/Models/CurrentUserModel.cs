using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace PerformanceAPI.Models
{
	public static class CurrentUserModel
	{
		// Set on Login
		public static int CurrentEmployeeID;
		public static int UserPositionID;
		public static string CurrentYear = DateTime.Now.ToString("yyyy");
		public static double CurrentBudge;
		public static List<int> ListOfSubordinates = new List<int>();
		public static List<int> ListOfSubordinatePositoin = new List<int>();
		public static int NumberOfEmployees;

		// Set in reports pages
		public static double OverBudgetAmount;
		public static bool CurrentReportYear;
		public static double CurrentBudgetUsed;
		//set in index page
		public static int NumberOfEmployeesWithProjections;
		public static int NumberOfEmployeesWithActuals;
		public static int NumberOfEmployeesWithCorrectProjections;

		public static string GetFormattedOverBudgetAmount()
		{
			string formattedAmount = Math.Abs(OverBudgetAmount).ToString("C");
			return formattedAmount;
		}
	}


}
