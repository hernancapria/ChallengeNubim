using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChallengeNubim.Models;
using ChallengeNubim.Services;
using System.Web.Security;
using ChallengeNubim.Contracts;
using ChallengeNubim.Helpers;

namespace ChallengeNubim.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario, string returnUrl)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.email, false);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);

                return RedirectToAction("Index", "Home");

            }
            TempData["mensaje"] = "Credenciales incorrectas";
            return View(usuario);

        }

        private bool IsValid(UsuarioModel usuario)
        {
            UserService userService = new UserService();
            // el metodo Hash es para hashear el pass, para cuando se crea el usuario, aca no se usa
            //var hash = SecurePasswordHasher.Hash(usuario.password);
            User user = userService.GetByEmail(usuario.email);
            var result = SecurePasswordHasher.Verify(usuario.password, user.password);
            return result;

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }

    

}