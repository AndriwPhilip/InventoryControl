using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlStock.Web.Controllers
{
    public class RegistrerController : Controller
    {
        [Authorize]
        public ActionResult ProductGroup()
        {
            return View();
        }
        [Authorize]
        public ActionResult ProductBrand()
        {
            return View();
        }
        [Authorize]
        public ActionResult StorageLocations()
        {
            return View();
        }
        [Authorize]
        public ActionResult UnitsofMeasure()
        {
            return View();
        }
        [Authorize]
        public ActionResult Products()
        {
            return View();
        }
        [Authorize]
        public ActionResult Countries()
        {
            return View();
        }
        [Authorize]
        public ActionResult States()
        {
            return View();
        }
        [Authorize]
        public ActionResult Cities()
        {
            return View();
        }
        [Authorize]
        public ActionResult Providers()
        {
            return View();
        }
        [Authorize]
        public ActionResult UsersProfile()
        {
            return View();
        }
        [Authorize]
        public ActionResult Users()
        {
            return View();
        }
    }
}