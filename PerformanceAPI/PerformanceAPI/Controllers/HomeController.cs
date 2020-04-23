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

namespace PerformanceAPI.Controllers
{
    public class HomeController : Controller
    {
        readonly GateWayClass _db = new GateWayClass();

        private readonly ILogger<HomeController> _logger;

        //test comment

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult PerformanceReport()
        {
            return View();
        }

        public IActionResult SalaryInformation()
        {
            return View();
        }

        public IActionResult Employee(int id)
        {
            // pass in from index
            id = 100004;
            List<EmployeeDetailsModel> empDetails = _db.DisplayAnEmployeesData(id).ToList();

            return View(empDetails);
        }

        public IActionResult PredictionSummaryReport(int Year)
        {
            //delete later
            Year = 2020;
            if(Year == 0)
            {
                return NotFound();
            }
            // this gets the list of models and passes them into the view
            List<PredictionSummaryReportModel> psrModel = _db.GetDataForPredictionSummaryReportModel(Year).ToList();
            if(psrModel == null)
            {
                return NotFound();
            }
            return View(psrModel);
        }

        public IActionResult ActualsSummaryReport(int Year)
        {
            // delete this later
            Year = 2020;
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
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public ActionResult EmployeeDetails(int id)
        {
            
            List<EmployeeDetailsModel> empDetails = _db.DisplayAnEmployeesData(id).ToList();

            return View("Employee", empDetails);

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
