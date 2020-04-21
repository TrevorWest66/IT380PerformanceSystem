using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceAPI.Gateway;

namespace PerformanceAPI.Models
{
    
    public class EmployeeModel
    {

        readonly GateWayClass _db = new GateWayClass();
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleIntial { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeGender { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeDateOfLastReview { get; set; }
        public string EmployeeActualPreformanceReview { get; set; }
        public string EmployeeCurrentSalary { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeProjectedPreformanceReview { get; set; }
        public string EmployeeProjectedSalaryIncrease { get; set; }

        /**
         * Gets the full name of the employee formated as LastName, FirstName MiddleIntial
         */
        public string getFormatedEmployeeFullName() 
        {
            string fullName = String.Format("{0}, {1} {2}", EmployeeLastName, EmployeeFirstName, EmployeeMiddleIntial);
            return fullName;
        }

        /**
         * Returns the date 1 year from the last performance review
         */
        public string getDateOfNextReview()
        {
            int yearOfLastReview = int.Parse(EmployeeDateOfLastReview.Substring(7));
            int yearOfNextReview = yearOfLastReview + 1;
            string dateOfNextReview = (EmployeeDateOfLastReview.Substring(0, 7)) + (yearOfNextReview.ToString());
            return dateOfNextReview;
        }

        public List<EmployeeModel> employeeLastandFirst()
        {
            List<EmployeeModel> employeeModel = _db.GetDataForEmployeeNameDropDown().ToList();
            return employeeModel;
        }
        

    }




}
