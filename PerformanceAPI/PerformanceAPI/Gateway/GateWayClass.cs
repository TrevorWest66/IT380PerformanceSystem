using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PerformanceAPI.Models;

namespace PerformanceAPI.Gateway
{
	public class GateWayClass
	{
		readonly string connectionString = "Data Source=it380federated.database.windows.net;Initial Catalog = Federated; User ID = orangeteam; Password=orange380!;Connect Timeout = 30; Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		//This will call the stored procedure for the PredictionsSummaryReport model
		public IEnumerable<PredictionSummaryReportModel> GetDataForPredictionSummaryReportModel(int Year)
		{
			// makes a list to store each record from the database whihc are loaded into the model
			List<PredictionSummaryReportModel> predictionSummaryReportModelList = new List<PredictionSummaryReportModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetDataForProjectionsReportModel", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				//set param
				cmd.Parameters.AddWithValue("@CurrentYear", Year);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					PredictionSummaryReportModel psrModel = new PredictionSummaryReportModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					if (CurrentUserModel.AcceptableSupervisorIds.Contains(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString()))
						|| CurrentUserModel.CurrentEmployeeID.Equals(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString())))
					{
						psrModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
						psrModel.FirstName = dr["E_FIRST_NAME"].ToString();
						psrModel.MiddleName = dr["E_MIDDLE_INTIAL"].ToString();
						psrModel.LastName = dr["E_LAST_NAME"].ToString();
						psrModel.ProjectedPR = dr["PR_PROJECTION"].ToString();
						psrModel.CurrentPosition = dr["POSITION_NAME"].ToString();
						psrModel.ProjectedPosition = dr["PROJECTED_POSITION"].ToString();
						psrModel.CurrentSalary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString());
						psrModel.SalaryIncrease = Convert.ToDouble(dr["SALARY_INCREASE_PROJECTION"].ToString());
						psrModel.Supervisor = Convert.ToInt32(dr["SUPERVISOR_ID"].ToString());
						psrModel.DateOfProjection = dr["DATE_OF_PROJECTION"].ToString()[0..^11];

						//adds the model with the records data in it to the list
						predictionSummaryReportModelList.Add(psrModel);
					}
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return predictionSummaryReportModelList;
		}

		public IEnumerable<EmployeeModel> GetDataForEmployeeNameDropDown()
		{
			// makes a list to store each record from the database which are loaded into the model
			List<EmployeeModel> employeeModelList = new List<EmployeeModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetEmpIDFirstLast", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					EmployeeModel employeeModel = new EmployeeModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					employeeModel.EmployeeLastName = dr["E_LAST_NAME"].ToString();
					employeeModel.EmployeeFirstName = dr["E_FIRST_NAME"].ToString();
					employeeModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());

					//adds the model with the records data in it to the list
					employeeModelList.Add(employeeModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return employeeModelList;
			;
		}

		public IEnumerable<EmployeeDetailsModel> DisplayAnEmployeesData(int id)
		{
			// makes a list to store each record from the database which are loaded into the model
			List<EmployeeDetailsModel> employeeDetailsModelList = new List<EmployeeDetailsModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("getEmployeesDetails", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.AddWithValue("@employeeID", id);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					EmployeeDetailsModel employeeDetailModel = new EmployeeDetailsModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					employeeDetailModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
					employeeDetailModel.FirstName = dr["E_FIRST_NAME"].ToString();
					employeeDetailModel.MiddleName = dr["E_MIDDLE_INTIAL"].ToString();
					employeeDetailModel.LastName = dr["E_LAST_NAME"].ToString();
					employeeDetailModel.Posistion = dr["POSITION_NAME"].ToString();
					employeeDetailModel.Team = dr["TEAM_NAME"].ToString();
					employeeDetailModel.Department = dr["DEPT_NAME"].ToString();
					employeeDetailModel.CurrentSalary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString());
					employeeDetailModel.SalaryFlag = Convert.ToBoolean(dr["SALARY_FLAG"].ToString());
					employeeDetailModel.HireDate = dr["HIRE_DATE"].ToString().Substring(0, 9);
					employeeDetailModel.SupervisorFirstName = dr["SUPERVISOR_FIRST_NAME"].ToString();
					employeeDetailModel.SupervisorLastName = dr["SUPERVISOR_LAST_NAME"].ToString();

					//adds the model with the records data in it to the list
					employeeDetailsModelList.Add(employeeDetailModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return employeeDetailsModelList;
			;
		}

		//This will call the stored procedure for ActualsSummaryReport model
		public IEnumerable<ActualsSummaryReportModel> GetDataForActualsSummaryReportModel(int Year)
		{
			// makes a list to store each record from the database whihc are loaded into the model
			List<ActualsSummaryReportModel> ActualsSummaryReportModelList = new List<ActualsSummaryReportModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetDataForActualsSummaryReport", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				//set parameter
				cmd.Parameters.AddWithValue("@CurrentYear", Year);

				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					ActualsSummaryReportModel asrModel = new ActualsSummaryReportModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					if (CurrentUserModel.AcceptableSupervisorIds.Contains(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString()))
						|| CurrentUserModel.CurrentEmployeeID.Equals(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString())))
					{
						asrModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
						asrModel.EmployeeFirstname = dr["E_FIRST_NAME"].ToString();
						asrModel.EmployeeMiddleInitial = dr["E_MIDDLE_INTIAL"].ToString();
						asrModel.EmployeeLastName = dr["E_LAST_NAME"].ToString();
						asrModel.PerformanceRating = dr["P_RATING_ID"].ToString();
						asrModel.CurrentPosition = dr["POSITION_NAME"].ToString();
						asrModel.PositionAfterReview = dr["PR_POSITION"].ToString();
						asrModel.Salary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString());
						asrModel.SupervisorID = Convert.ToInt32(dr["SUPERVISOR_ID"].ToString());
						asrModel.DateOfReview = dr["DATE_OF_REVIEW"].ToString()[0..^11];

						//adds the model with the records data in it to the list
						ActualsSummaryReportModelList.Add(asrModel);
					}
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return ActualsSummaryReportModelList;
		}

		public IEnumerable<ReportsHistoryModel> GetDataForReportsHistoryModel()
		{
			// makes a list to store each record from the database whihc are loaded into the model
			List<ReportsHistoryModel> ReportHistoryModelsList = new List<ReportsHistoryModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetDataForReportsHistory", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					//instantiates a new model
					ReportsHistoryModel rhModel = new ReportsHistoryModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					if (CurrentUserModel.CurrentEmployeeID.Equals(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
					{
						rhModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
						rhModel.Budget = Convert.ToDouble((dr["BUDGET"].ToString())).ToString("C");
						rhModel.BudgetYear = Convert.ToInt32(dr["BUDGET_PERIOD"].ToString().Substring(6, 4));

						//adds the model with the records data in it to the list
						ReportHistoryModelsList.Add(rhModel);
					}
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return ReportHistoryModelsList;
		}


		//next method for a stored procedure goes here

	}
}
