using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAPI.Models;
using PerformanceAPI.Gateway;

namespace PerformanceAPI.Controllers
{
    public class ProjectionEmployeesViewComponent : ViewComponent
    {
        readonly GateWayClass _db = new GateWayClass();
        public IViewComponentResult Invoke()
        {
            List<EmployeeListProjectionsModel> projection = _db.GetEmployeesForProjections().ToList();
            return View(projection);
        }
    }
}
