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
    public class PositionViewComponent : ViewComponent
    {
        readonly GateWayClass _db = new GateWayClass();
        public IViewComponentResult Invoke()
        {
            List<PositionsModel> position = _db.DisplayPositionInformation().ToList();
            return View(position);
        }
    }
}
