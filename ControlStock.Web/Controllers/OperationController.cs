using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlStock.Web.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        [Authorize]
        public ActionResult ProductInput()
        {
            return View();
        }
        [Authorize]
        public ActionResult ProductOutput()
        {
            return View();
        }
        [Authorize]
        public ActionResult LossRelease()
        {
            return View();
        }
        [Authorize]
        public ActionResult Inventory()
        {
            return View();
        }
    }
}