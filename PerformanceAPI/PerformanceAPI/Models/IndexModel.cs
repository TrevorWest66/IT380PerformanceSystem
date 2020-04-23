using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class IndexModel
    {
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string PositionName { get; set; }
        public string PredictionRating { get; set; }
        public string ActualRating { get; set; }
        public double PredictionSalary { get; set; }
        public double ActualSalary { get; set; }
        public int Supervisor { get; set; }
    

        //derived attributes
        public bool PredictionActualized;
    }
}
