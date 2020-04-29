﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PerformanceAPI.Models;
using static PerformanceAPI.Models.db;

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
					if (CurrentUserModel.ListOfSubordinates.Contains(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
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
					if (CurrentUserModel.ListOfSubordinates.Contains(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
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
			List<EmployeeDetailsModel> employeeDetailsModelList = new List<EmployeeDetailsModel>();

			using (SqlConnection con = new SqlConnection(connectionString))

			{
				SqlCommand cmd = new SqlCommand("getDataForEmployeeDetailsTable", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.AddWithValue("@EmployeeID", id);
				cmd.Parameters.AddWithValue("@CurrentYear", CurrentUserModel.CurrentYear);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
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
					employeeDetailModel.CurrentSalary = Convert.ToDouble(dr["PAY_AMOUNT"].ToString()).ToString("N");
					employeeDetailModel.SalaryFlag = salaryFlagToString(Convert.ToBoolean(dr["SALARY_FLAG"]));
					employeeDetailModel.HireDate = dr["HIRE_DATE"].ToString().Split(" ")[0];
					employeeDetailModel.SupervisorFirstName = dr["SUPERVISOR_FIRST_NAME"].ToString();
					employeeDetailModel.SupervisorLastName = dr["SUPERVISOR_LAST_NAME"].ToString();
					employeeDetailModel.LastReviewDate = nullReviewDate(dr["LAST_REVIEW_DATE"].ToString());
					employeeDetailModel.ProjectedPosition = nullProjection(dr["PROJECTED_POSITION"].ToString());
					employeeDetailModel.DateOfProjection = nullProjectionDate(dr["DATE_OF_PROJECTION"].ToString());
					employeeDetailModel.ProjectedSalaryIncrease = decimalToPrecentString(dr["SALARY_INCREASE_PROJECTION"].ToString());
					employeeDetailModel.ProjectedRating = nullProjection(dr["PR_PROJECTION"].ToString());
					employeeDetailModel.ProjectionComments = nullProjectionComments(dr["COMMMENTS"].ToString());

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

		public string nullReviewDate(string review)
		{
			if (String.IsNullOrEmpty(review))
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
		public string salaryFlagToString(Boolean boo)
		{
			if (boo)
			{
				return "Salary";
			}
			else
			{
				return "Hourly";
			}
		}

		public string nullProjectionComments(string projecton)
		{
			if (String.IsNullOrEmpty(projecton))
			{
				return "-----";
			}
			else
			{
				return projecton;
			}
		}

		/**
		 * Returns "-----" if the projection is null or ""
		 */
		public string nullProjection(string projection)
		{
			if (String.IsNullOrEmpty(projection))
			{
				return "-----";
			}
			else
			{
				return projection;
			}
		}


		public string decimalToPrecentString(string increase)
		{
			if (String.IsNullOrEmpty(increase))
			{
				return "-----";
			}
			double increaseint = Convert.ToDouble(increase);
			return ((increaseint * 100).ToString() + "%");
		}

		/**
		 * Returns "A projection has not been made." if the projection is null or ""
		 */
		public string nullProjectionDate(string projection)
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




	public IEnumerable<EmployeeListProjectionsModel> GetEmployeesForProjections()
		{
			// makes a list to store each record from the database which are loaded into the model
			List<EmployeeListProjectionsModel> employeeProjectionsList = new List<EmployeeListProjectionsModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetEmployeeDetailsForProjectionsPage", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.AddWithValue("@CurrentYear", DateTime.Now.ToString("yyyy"));
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					if (CurrentUserModel.ListOfSubordinates.Contains(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
					{
						//instantiates a new model
						EmployeeListProjectionsModel employeeModel = new EmployeeListProjectionsModel();
						//IMPORTANT! the text after DR needs to match the column name in the data base exactly
						employeeModel.LastName = dr["E_LAST_NAME"].ToString();
						employeeModel.FirstName = dr["E_FIRST_NAME"].ToString();
						employeeModel.EmployeeID = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString());
						employeeProjectionsList.Add(employeeModel);
					}
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return employeeProjectionsList;
		}

		public IEnumerable<PositionsModel> DisplayPositionInformation()
		{
			// makes a list to store each record from the database which are loaded into the model
			List<PositionsModel> positionList = new List<PositionsModel>();

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetAllPositions", con)
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
					PositionsModel positionModel = new PositionsModel();
					//IMPORTANT! the text after DR needs to match the column name in the data base exactly
					positionModel.PositionID = Convert.ToInt32(dr["POSITION_ID"].ToString());
					positionModel.PositionName = dr["POSITION_NAME"].ToString();
					positionModel.SalaryLowerBound = Convert.ToDouble(dr["POSITION_SALARY_LOWER"].ToString()).ToString("N");
					positionModel.SalaryUpperBound = Convert.ToDouble(dr["POSITION_SALARY_UPPER"].ToString()).ToString("N");

					//adds the model with the records data in it to the list
					positionList.Add(positionModel);
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return positionList;
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
					if (CurrentUserModel.ListOfSubordinates.Contains(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
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

		public void AddProjectionsDataToProjectionsTable(ProjectionsModel model)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("AddNewProjections", con)
				{
					CommandType = CommandType.StoredProcedure
				};
				cmd.Parameters.AddWithValue("@EmployeeID", model.EmployeeID);
				cmd.Parameters.AddWithValue("@PrProjection", model.ProjectedRating);
				cmd.Parameters.AddWithValue("@SalaryIncrease", model.ProjectedSalaryIncrease);
				cmd.Parameters.AddWithValue("@ProjectedPosition", model.ProjectedPosition);
				cmd.Parameters.AddWithValue("@Comments", model.ProjectionsComments);

				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
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
					if (CurrentUserModel.ListOfSubordinates.Contains(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString())))
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
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
			//returns the list of models
			return indexModelList;
		}

		public void GetBudgetForCurrentUser()
		{

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetCurrentBudget", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				cmd.Parameters.AddWithValue("@EmployeeID", CurrentUserModel.CurrentEmployeeID);
				cmd.Parameters.AddWithValue("@Year", CurrentUserModel.CurrentYear);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					CurrentUserModel.CurrentBudge = Convert.ToDouble(dr["BUDGET"].ToString());
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
		}

		public void GetSubordinatesForCurrentUser()
		{

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetUsersSubordinates", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				//set the params
				cmd.Parameters.AddWithValue("@CurrentUser", CurrentUserModel.CurrentEmployeeID);
				cmd.Parameters.AddWithValue("@CurrentPositionID", CurrentUserModel.UserPositionID);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					CurrentUserModel.ListOfSubordinates.Add(Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()));
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
		}

		public void GetPositionIdForCurrentUser()
		{

			//makes the connection
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				//makes the command for the stored procedure
				//and sets its type
				// IMPORTANT! the string neeeds to match the name of the stored procedure exactly
				SqlCommand cmd = new SqlCommand("GetUserPositionID", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				//set the params
				cmd.Parameters.AddWithValue("@EmployeeID", CurrentUserModel.CurrentEmployeeID);
				//opens the connection
				con.Open();
				//executes the stored procedure
				SqlDataReader dr = cmd.ExecuteReader();
				//creates the model objexts for each row and adds them to the list
				while (dr.Read())
				{
					CurrentUserModel.UserPositionID = Convert.ToInt32(dr["POSITION_ID"].ToString());
				}
				//IMPORTANT! dont forget to close the connection
				con.Close();
			}
		}

		//next method for a stored procedure goes here

	}
}
