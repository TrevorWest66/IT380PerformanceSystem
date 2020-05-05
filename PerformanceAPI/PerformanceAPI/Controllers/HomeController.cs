using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerformanceAPI.Models;
using PerformanceAPI.Gateway;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PerformanceAPI.Controllers
{
    public class HomeController : Controller
    {
        readonly GateWayClass _db = new GateWayClass();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int year = Convert.ToInt32(CurrentUserModel.CurrentYear);

            List<IndexModel> indModel = _db.GetDataForIndexModel(year).ToList();
            return View(indModel);
        }

        public IActionResult Login()
        {
            CurrentUserModel.ListOfSubordinates.Clear();
            CurrentUserModel.ListOfSubordinatePositoin.Clear();
            PerformanceRatingModel.listOfRatingInfo.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind] LoginModel user)
        {
            try
            {
                if (ModelState.IsValid) {
                    CurrentUserModel.CurrentEmployeeID = Convert.ToInt32(user.UserID);

                    _db.GetPerformanceRatingInfo();
                    _db.GetPositionIdForCurrentUser();
                    _db.GetBudgetForCurrentUser();
                    _db.GetSubordinatesForCurrentUser();

                    CurrentUserModel.NumberOfEmployees = CurrentUserModel.ListOfSubordinates.Count;

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public IActionResult SalaryInformation()
        {

            var together = (_db.DisplayTargetIncrease() ?? Enumerable.Empty<PositionsModel>()).Concat(_db.DisplayRangeInformation() ?? Enumerable.Empty<PositionsModel>()).ToList();
            return View(together);

        }

        public IActionResult Employee(int id)
        {
            if (id.Equals(null))
            {
                return View("Employee");
            }
            List<EmployeeDetailsModel> empDetails = _db.DisplayAnEmployeesData(id).ToList();

            return View(empDetails);
        }

        public IActionResult PredictionSummaryReport(int Year)
        {
            if (Year == 2020)
            {
                CurrentUserModel.CurrentReportYear = true;
            }
            else
            {
                CurrentUserModel.CurrentReportYear = false;
            }

            if (Year == 0)
            {
                return NotFound();
            }
            // this gets the list of models and passes them into the view
            List<PredictionSummaryReportModel> psrModel = _db.GetDataForPredictionSummaryReportModel(Year).ToList();
            if (psrModel == null)
            {
                return NotFound();
            }
            return View(psrModel);
        }

        public IActionResult ActualsSummaryReport(int Year)
        {
            if(Year == 2020)
            {
                CurrentUserModel.CurrentReportYear = true;
            }
            else
            {
                CurrentUserModel.CurrentReportYear = false;
            }

            if (Year == 0)
            {
                return NotFound();
            }
            List<ActualsSummaryReportModel> asrModel = _db.GetDataForActualsSummaryReportModel(Year).ToList();
            if (asrModel == null)
            {
                return NotFound();
            }
            return View(asrModel);
        }


        public IActionResult Projections()
        {
            List<EmployeeListProjectionsModel> empList = _db.GetEmployeesForProjections().ToList();
            ViewBag.EmployeeList = new SelectList(empList, "EmployeeID", "LastName");

            return View();

        }

        public IActionResult Details()
        {
            return View();
        }

        public ActionResult EmployeeDetails(int id)
        {
            if (id.Equals(null))
            {
                return View("Projections");
            }
            List<EmployeeDetailsModel> empDetails = _db.DisplayAnEmployeesData(id).ToList();

            return View("Employee", empDetails);

        }

        public ActionResult PositionNames()
        {
            
            List<PositionsModel> positions = _db.DisplayPositionInformation().ToList();

            return View("Projections", positions);

        }

        public IActionResult ReportsHistory()
        {
            List<ReportsHistoryModel> reports = _db.GetDataForReportsHistoryModel().ToList();
            return View(reports);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SaveProjection(EmployeeListProjectionsModel model)
        {
            if (ModelState.IsValid)
            {

                ProjectionsModel projection = new ProjectionsModel();
                if (String.IsNullOrEmpty(model.comments))
                {
                    projection.ProjectionsComments = "No comments";
                }
                else
                {
                    projection.ProjectionsComments = model.comments;
                }

                projection.EmployeeID = model.EmployeeID;
                projection.ProjectedPosition = model.projectedPosition;
                projection.ProjectedSalaryIncrease = (Convert.ToDouble(model.projectedSalaryIncrease.TrimEnd('%')) / 100);
                projection.ProjectedRating = model.projectedReview;

                _db.AddProjectionsDataToProjectionsTable(projection);
                return RedirectToAction("Projections");
            }
            else
            {
                return RedirectToAction("Projections");
            }

        }

            public IActionResult EditProjection(int id)
            {
                if (id == 0)
                {
                    return NotFound();
                }

                ProjectionsModel projection = _db.GetMostRecentProjectionForAnEmployee(id);
                projection.ProjectedSalaryIncreaseString = projection.ProjectedSalaryIncrease.ToString("P");
                
                if (projection == null)
                {
                    return NotFound();
                }
                return View(projection);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProjection(int id, [Bind] ProjectionsModel projection)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    projection.EmployeeID = id;
                    if(projection.ProjectionsComments is null)
                    {
                        projection.ProjectionsComments = "--";
                    }

                    projection.ProjectedSalaryIncrease = Convert.ToDouble(projection.ProjectedSalaryIncreaseString.TrimEnd('%')) / 100;
                    _db.UpdateProjectionByID(projection);
                    return RedirectToAction("PredictionSummaryReport", new { Year = Convert.ToInt32(CurrentUserModel.CurrentYear)});
                }
                return View(_db);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult PerformanceReview(int id)
        {
            {
                PerformanceReviewModel prModel = _db.GetDataForPerformanceReviewPage(id);
                prModel.ReviewDate = DateTime.Now.ToString();
                prModel.ReviewPeriod = "01-01-" + CurrentUserModel.CurrentYear + "-12-31-" + CurrentUserModel.CurrentYear;
                prModel.PayIncreaseString = prModel.PayIncreaseNumber.ToString("P");
                return View(prModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PerformanceReview(int id, [Bind] PerformanceReviewModel prReview)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    prReview.EmployeeID = id;
                    if (prReview.PrLastRating is null)
                    {
                        prReview.PrLastRating = "--";
                    }
                    if (prReview.Comments is null)
                    {
                        prReview.Comments = "--";
                    }
                    prReview.PayIncreaseNumber = (Convert.ToDouble(prReview.PayIncreaseString.TrimEnd('%')) / 100);
                    _db.InsertPerformanceReview(prReview);
                    return RedirectToAction("Index");
                }
                prReview.EmployeeID = id;
                return View(_db);
            }
            catch
            {
                return View();
            }
        }

    }

}
