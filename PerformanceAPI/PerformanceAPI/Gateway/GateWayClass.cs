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
					if (CurrentUserModel.AcceptableSupervisorIds.Contains(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString()))
						|| CurrentUserModel.CurrentEmployeeID.Equals(Convert.ToInt32(dr["SUPERVISOR_ID"].ToString())))
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
				SqlCommand cmd = new SqlCommand("getDataForEmployeeDetailsTable", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.AddWithValue("@EmployeeID", id);
				cmd.Parameters.AddWithValue("@CurrentYear", DateTime.Now.ToString("yyyy"));
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
					employeeDetailModel.SalaryFlag = salaryFlagToString(Convert.ToBoolean(dr["SALARY_FLAG"]));
					employeeDetailModel.HireDate = dr["HIRE_DATE"].ToString().Split(" ")[0];
					employeeDetailModel.SupervisorFirstName = dr["SUPERVISOR_FIRST_NAME"].ToString();
					employeeDetailModel.SupervisorLastName = dr["SUPERVISOR_LAST_NAME"].ToString();
					employeeDetailModel.LastReviewDate = nullReviewDate(dr["LAST_REVIEW_DATE"].ToString());
					employeeDetailModel.ProjectedPosition = nullProjection(dr["PROJECTED_POSITION"].ToString());
					employeeDetailModel.DateOfProjection = nullProjectionDate(dr["DATE_OF_PROJECTION"].ToString());
					employeeDetailModel.ProjectedSalaryIncrease = decimalToPrecentString(dr["SALARY_INCREASE_PROJECTION"].ToString());
					employeeDetailModel.ProjectedRating = nullProjection(dr["PR_PROJECTION"].ToString());

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

		private string nullReviewDate (string review)
		{
			if (review.Equals("") || review.Equals(null))
			{
				return "This employee has not been reviewed.";
			}
			else
			{
				return review.Split(" ")[0];
			}
		}

		/**
		 * Returns "Salary" or "Hourly" depending on the pay type
		 */
		private string salaryFlagToString(Boolean boo)
		{
			if (boo)
			{
				return "Salary";
			} else
			{
				return "Hourly";
			}
		}

		/**
		 * Returns "-----" if the projection is null or ""
		 */
		private string nullProjection(string projection)
		{
			if (projection.Equals("") || projection.Equals(null)) {
				return "-----";
			}
			else
			{
				return projection;
			}
		}

		private string decimalToPrecentString(string increase)
		{
			if (increase.Equals("") || increase.Equals(null))
			{
				return "-----";
			}
			double increaseint = Convert.ToDouble(increase);
			return ((increaseint * 100).ToString() + "%");
		}

		/**
		 * Returns "A projection has not been made." if the projection is null or ""
		 */
		private string nullProjectionDate(string projection)
		{
			if (projection.Equals("") || projection.Equals(null))
			{
				return "A projection has not been made.";
			}
			else
			{
				return projection.Split(" ")[0];
			}
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

		//This will call the stored procedure for thr Index model
		public IEnumerable<IndexModel> GetDataForIndexModel(int Year)
		{
			//makes a list to store each record from the database whhich are loaded into the model
			List<IndexModel> indexModelList = new List<IndexModel>();

			//makes the coonection
			using (SqlConnection con = new SqlConnection(connectionString))
			{

				//makes the command for the stored procedure
				//and set its type
				//IMPORTANT! the string needs to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetDataForIndexModel", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				//set parameter
				cmd.Parameters.AddWithValue("@CurrentYear", Year);

				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model projects for each row and adds them to the list
				while (dr.Read())
				{

					//instantiates a new model
					IndexModel indModel = new IndexModel();

					//IMPORTANT! the text after DR needs to match the column name in the data base exactly 
					indModel.FirstName = dr["E_FIRST_NAME"].ToString();
					indModel.MiddleInitial = dr["E_MIDDLE_INTIAL"].ToString();
					indModel.LastName = dr["E_LAST_NAME"].ToString();
					indModel.PositionName = dr["POSITION_NAME"].ToString();
					indModel.PredictionRating = dr["PR_PROJECTION"].ToString();
					indModel.ActualRating = dr["PR_LAST_RATING"].ToString();
					indModel.PredictionSalary = Convert.ToDouble(dr["SALARY_INCREASE_PROJECTION"].ToString());
					indModel.ActualSalary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString());
					indModel.Supervisor = Convert.ToInt32(dr["SUPERVISOR_ID"].ToString());

					//adds the model with the records data in it to the list
					indexModelList.Add(indModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return indexModelList;
		}
		//next method for a stored procedure goes here
	}
}
