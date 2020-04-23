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
    public class EmployeeViewComponent : ViewComponent
    {
        readonly GateWayClass _db = new GateWayClass();
        public IViewComponentResult Invoke()
        {
            List<EmployeeModel> empModel = _db.GetDataForEmployeeNameDropDown().ToList();
            return View(empModel);
        }

    }
}