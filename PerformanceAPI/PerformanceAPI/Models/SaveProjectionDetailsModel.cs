using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace PerformanceAPI.Models
{
    public class SaveProjectionDetailsModel
    {
        readonly string connectionString = "Data Source=it380federated.database.windows.net;Initial Catalog = Federated; User ID = orangeteam; Password=orange380!;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int EmployeeID { get; set; }
        public string ProjectedRating { get; set; }
        public string ProjectedSalaryIncrease { get; set; }
        public string ProjectedPosition { get; set; }
        public string ProjectionsComments { get; set; }
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
