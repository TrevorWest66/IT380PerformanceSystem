using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PerformanceAPI.Models;
using PerformanceAPI.Gateway;

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

        public IActionResult Employee()
        {
            List<EmployeeModel> empModel = _db.GetDataForEmployeeNameDropDown().ToList();
            return View(empModel);
        }

        public IActionResult PredictionSummaryReport()
        {
            // this gets the list of models and passes them into the view
            List<PredictionSummaryReportModel> psrModel = _db.GetDataForPredictionSummaryReportModel().ToList();
            return View(psrModel);
        }

        public IActionResult ActualsSummaryReport()
        {
            return View();
        }

        public IActionResult Projections()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
