using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlStock.Web.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Reporting
        [Authorize]
        public ActionResult InventoryPosition()
        {
            return View();
        }
        [Authorize]
        public ActionResult Resupply()
        {
            return View();
        }
    }
}