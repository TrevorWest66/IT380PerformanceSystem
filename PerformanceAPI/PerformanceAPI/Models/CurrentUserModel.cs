using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace PerformanceAPI.Models
{
	public static class CurrentUserModel
	{
		public static int CurrentBudge = 1100000;
		public static int CurrentBudgetUsed;
		public static int NumberOfEmployeesWithProjections;
		public static int NumberOfEmployees = 15;
		public static int[] acceptableSupervisorIds = { 100002, 100004, 100005 };
		public static int overBudgetAmount;

		public static string GetFormattedOverBudgetAmount()
		{
			string formattedAmount = "$" + Math.Abs(overBudgetAmount).ToString("N");
			return formattedAmount;
		}
	}


}
