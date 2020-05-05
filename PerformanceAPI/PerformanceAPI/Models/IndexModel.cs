using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class IndexModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string ProjectedPositionName { get; set; }
        public string ActualPositionName { get; set; }
        public string PredictionRating { get; set; }
        public string ActualRating { get; set; }
        public double PredictionSalary { get; set; }
        public string FormattedPredictionSalary { get; set; }
        public double ActualSalaryIncrease { get; set; }
        public string FormattedActualSalaryIncrease { get; set; }
        public string DateOfProjection { get; set; }
        public string DateOfActuals { get; set; }
        public int SupervisorID { get; set; }
        public bool ShowArrow { get; set; }


        public List<EmployeeTreeViewModel> etvModelList { get; set; }


        //derived attributes
        public bool PredictionActualized;
    }
}
