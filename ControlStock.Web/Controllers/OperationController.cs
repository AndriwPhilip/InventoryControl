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
        public ActionResult ProductInput()
        {
            return View();
        }
        public ActionResult ProductOutput()
        {
            return View();
        }
        public ActionResult LossRelease()
        {
            return View();
        }
        public ActionResult Inventory()
        {
            return View();
        }
    }
}