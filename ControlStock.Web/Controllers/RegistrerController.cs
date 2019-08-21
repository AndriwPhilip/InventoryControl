using System;
using ControlStock.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlStock.Web.Controllers
{
    public class RegistrerController : Controller
    {
        private static List<ProductGroupModel> _listProductGroup = new List<ProductGroupModel>()
        {
            new ProductGroupModel() { Id = 1, Name="Livros", Active=true, },
            new ProductGroupModel() { Id = 2, Name = "Cadernos", Active = true, },
            new ProductGroupModel() { Id = 3, Name = "Pelu", Active = false, }
        };

        [Authorize]
        public ActionResult ProductGroup()
        {
            return View(_listProductGroup);
        }
        [HttpPost]
        [Authorize]
        public ActionResult RecoverProductGroup( int id)
        {
            return Json(_listProductGroup.Find(x => x.Id == id));
        }

        
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