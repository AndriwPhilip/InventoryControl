using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlStock.Web.Controllers
{
    public class GraphicsController : Controller
    {
        // GET: Graphics
        [Authorize]
        public ActionResult LossesPerMonth()
        {
            return View();
        }
        [Authorize]
        public ActionResult InputVsOutputPerMonth()
        {
            return View();
        }
    }
}