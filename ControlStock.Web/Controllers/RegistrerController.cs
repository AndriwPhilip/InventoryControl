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

        [Authorize]
        public ActionResult ProductGroup()
        {
            return View(ProductGroupModel.RecoverList());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecoverProductGroup(int id)
        {
            return Json(ProductGroupModel.RecoverById(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveProductGroup(int id)
        {
            return Json(ProductGroupModel.RemoveById(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult SaveProductGroup(ProductGroupModel model)
        {
            var result = "OK";
            var message = new List<string>();
            var idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                result = "AVISO";
                message = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var id = model.Save();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        result = "ERRO";
                    }

                }
                catch (Exception ex)
                {
                    result = "ERRO";
                }

            }
            return Json(new { Resultado = result, Mensagens = message, IdSalvo = idSalvo });
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