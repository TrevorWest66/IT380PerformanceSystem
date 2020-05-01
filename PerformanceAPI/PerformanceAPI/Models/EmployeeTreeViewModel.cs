using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PerformanceAPI.Gateway;

namespace PerformanceAPI.Models

{ 
    public class EmployeeTreeViewModel
    {
        readonly GateWayClass _db = new GateWayClass();

        public int EmployeeID { get; set; } 
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleInitial { get; set; }
        public string EmployeeLastName { get; set; }
        public int SupervisorID { get; set; }

        //Gets the full name of the employee formated as LastName, FirstName MiddleInitial
        public string getFormatedEmpName()
        {
            string FullName = String.Format("{0},{1} {2}", EmployeeLastName, EmployeeFirstName, EmployeeMiddleInitial);
            return FullName;
        }

        

      
    }

}
