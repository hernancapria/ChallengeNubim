using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChallengeNubim.Models;
using ChallengeNubim.Services;

namespace ChallengeNubim.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {

        // GET: Usuario
        public ActionResult Index()
        {
            UsuarioModel model = new UsuarioModel();
            ConfigurePage(ref model);
            return View(model);

        }

        

        public ActionResult GetData()
        {
            UserService userService = new UserService();
            var listUsers = userService.GetAll();
            return Json(new { data = listUsers }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                UsuarioModel model = new UsuarioModel();
                ConfigurePage(ref model);
                return View(model);
            }
            else
            {
                UserService userService = new UserService();
                var model = userService.Get(id);
                return Json(model, JsonRequestBehavior.AllowGet);
            }


        }


        [HttpPost]
        public ActionResult AddOrEdit(UsuarioModel userModel)
        {
            if (ValidateModel(userModel))
            {
                if (userModel.id == 0)
                {
                    UserService userService = new UserService();
                    userService.Insert(userModel);
                    return Json(userModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    UserService userService = new UserService();
                    userService.Update(userModel);
                    return Json(userModel, JsonRequestBehavior.AllowGet);

                }
            }
            else
            {
                return new HttpStatusCodeResult(500, "Error en el modelo");
            }

            
        }

        private bool ValidateModel(UsuarioModel userModel)
        {
            ModelState.Remove("id");
            return (ModelState.IsValid);
        }

        private void ConfigurePage(ref UsuarioModel model)
        {
            PaisService paisService = new PaisService();
            var paises = paisService.GetAll();
            model = new UsuarioModel
            {
                Paises = paises
            };

            // se puede pasar tambien en un viewbag (aunq no es la mejor practica)
            ViewBag.Paises = GetDropDownPaises();

        }

        private List<SelectListItem> GetDropDownPaises()
        {
            PaisService paisService = new PaisService();
            var paises = paisService.GetAll();
            List<SelectListItem> paisesDropDown = new List<SelectListItem>();
            paisesDropDown.Add(new SelectListItem
            {
                Text = "- Seleccione una opcion -",
                Value = "0"
            });
            foreach (var c in paises)
            {
                paisesDropDown.Add(new SelectListItem
                {
                    Text = c.descripcion,
                    Value = c.id.ToString()
                });
            }
            return paisesDropDown;
        }





        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            UserService userService = new UserService();
            var user = userService.Get(id);
            userService.Update(user);

            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            UserService userService = new UserService();
            userService.Delete(id);
            return new EmptyResult();
            
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
