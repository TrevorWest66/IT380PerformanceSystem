using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
	public class PerformanceRatingListModel
	{
		public string RatingID { get; set; }
		public string LowerBound { get; set; }
		public string Target { get; set; }
		public string UpperBound { get; set; }

		public PerformanceRatingListModel(string ID, string lower, string goal, string upper)
		{
			RatingID = ID;
			LowerBound = lower;
			Target = goal;
			UpperBound = upper;
		}
	}
}
