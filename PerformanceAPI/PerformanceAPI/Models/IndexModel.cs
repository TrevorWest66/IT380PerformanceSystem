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
        public string PositionName { get; set; }
        public string PredictionRating { get; set; }
        public string ActualRating { get; set; }
        public double PredictionSalary { get; set; }
        public double ActualSalary { get; set; }
        public string DateOfProjection { get; set; }
        public string DateOfActuals { get; set; }
        public string PerformanceReview { get; set; }
        public int SupervisorID { get; set; }



        public List<EmployeeTreeViewModel> etvModelList { get; set; }


        //derived attributes
        public bool PredictionActualized;
    }
}
