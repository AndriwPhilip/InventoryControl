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
        public ActionResult LossesPerMonth()
        {
            return View();
        }
        public ActionResult InputVsOutputPerMonth()
        {
            return View();
        }
    }
}