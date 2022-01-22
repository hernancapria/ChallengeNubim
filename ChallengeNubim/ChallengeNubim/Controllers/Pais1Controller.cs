using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChallengeNubim.Models;
using ChallengeNubim.Services;

namespace ChallengeNubim.Controllers
{
    public class Pais1Controller : Controller
    {
        // GET: Pais1
        public ActionResult Index()
        {
            PaisModel model = new PaisModel();
            ConfigurePage(ref model);
            return View(model);
        }


        public ActionResult GetData()
        {
            PaisService PaisService = new PaisService();
            var listUsers = PaisService.GetAll();
            return Json(new { data = listUsers }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                PaisModel model = new PaisModel();
                ConfigurePage(ref model);
                return View(model);
            }
            else
            {
                PaisService PaisService = new PaisService();
                var model = PaisService.Get(id);
                return Json(model, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        public ActionResult AddOrEdit(PaisModel userModel)
        {
            if (ValidateModel(userModel))
            {
                if (userModel.id == 0)
                {
                    PaisService PaisService = new PaisService();
                    PaisService.Insert(userModel);
                    return Json(userModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    PaisService PaisService = new PaisService();
                    PaisService.Update(userModel);
                    return Json(userModel, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                return new HttpStatusCodeResult(500, "Error en el modelo");
            }


        }

        private bool ValidateModel(PaisModel userModel)
        {
            ModelState.Remove("id");
            return (ModelState.IsValid);
        }

        private void ConfigurePage(ref PaisModel model)
        {
            

        }

        


        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            PaisService PaisService = new PaisService();
            var user = PaisService.Get(id);
            PaisService.Update(user);

            return View();
        }


        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            PaisService PaisService = new PaisService();
            PaisService.Delete(id);
            return new EmptyResult();

        }




    }
}