using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class PerformanceReviewModel
    {
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public int EmployeeID
        { get; set; }
        public string EmployeePosition
        { get; set; }
        public string Supervisor
        { get; set; }
        public string ReviewDate
        { get; set; }
        public string PerformanceRatingID
        { get; set; }
        public string PrLastRating { get; set; }
        public string Department { get; set; }
        public string DateOfNextReview { get; set; }
        public string Promotion { get; set; }
        public double PayIncrease { get; set; }
        public string ReviewPeriod
        { get; set; }
        public string Comments
        { get; set; }
    }
}
    
   
    



