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
        // GET: /Usuario/Logput/
        [HttpGet]
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
            return View();
        }

        //
        // POST: /Usuario/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioConjunto.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }


        //
        // GET: /Usuario/Details/5
        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.UsuarioConjunto.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.UsuarioConjunto.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.UsuarioConjunto.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.UsuarioConjunto.Find(id);
            db.UsuarioConjunto.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}