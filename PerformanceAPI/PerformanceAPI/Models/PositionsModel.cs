using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class PositionsModel
    {
        public int PositionID { get; set; }
        public string PositionName { get; set;}
        public string SalaryLowerBound { get; set; }
        public string SalaryUpperBound { get; set; }
        public string RatingName { get; set; }
        public string MGLowerBound { get; set; }
        public string MGTarget { get; set; }
        public string MGUpperBound { get; set; }

    }
}
