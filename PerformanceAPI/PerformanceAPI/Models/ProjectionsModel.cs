using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceAPI.Models
{
    public class ProjectionsModel
    {
        public int EmployeeID { get; set; }
        // used for submitting the projections
        public string ProjectedRating { get; set; }
        public double ProjectedSalaryIncrease { get; set; }
        public string ProjectedPosition { get; set; }
        public string ProjectionsComments { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string DateOfProjection { get; set; }

        /*
       public int SaveProjectionDetails()
       {

           SqlConnection con = new SqlConnection(connectionString);
           string query = "INSERT INTO PROJECTIONS(EMPLOYEE_ID, DATE_OF_PROJECTION, PR_PROJECTION, SALARY_INCREASE_PROJECTION, PROJECTED_POSITION) values (" + EmployeeID + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + ProjectedRating + "','"+ ProjectedSalaryIncrease + "','" + ProjectedPosition + "','" + ProjectionsComments + "')";
           foreach (SaveProjectionDetailsModel projection in )
           {
               SqlCommand cmd = new SqlCommand(query, con);
           }

           con.Open();
           //int i = cmd.ExecuteNonQuery();
           con.Close();
           //return i;
       }*/

    }
}
