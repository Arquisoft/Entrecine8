using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;
using System.Web.Security;

namespace EntrecineWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();


        //
        // GET: /Usuario/Login/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        //
        // GET: /Usuario/Login/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginModel usuarioLogin)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = db.UsuarioConjunto.FirstOrDefault<Usuario>(x => x.Login == usuarioLogin.Login && x.Password == usuarioLogin.Password);
                if (usuario != null)
                {
                    FormsAuthentication.SetAuthCookie(usuarioLogin.Login, usuarioLogin.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña es incorrecta");
                }
            }
            return View(usuarioLogin);
        }

        //
        // GET: /Usuario/Logout/
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            return View(db.UsuarioConjunto.ToList());
        }

        //
        // GET: /Usuario/Registro

        public ActionResult Registro()
        {
            //Seguridad
            Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(User.Identity.Name));
            if (user == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //
        // POST: /Usuario/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(db.UsuarioConjunto.FirstOrDefault(u => u.Login == usuario.Login) != null){
                    ModelState.AddModelError("", "Este usuario ya está registrado");
                    return View(usuario);
                }

                db.UsuarioConjunto.Add(usuario);
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(usuario.Login,true);
                return RedirectToAction("Index","Home");
            }

            return View(usuario);
        }

    }
}