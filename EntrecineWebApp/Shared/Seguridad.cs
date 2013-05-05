using EntrecineWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntrecineWebApp.Shared
{
    public static class Seguridad
    {
        public static ActionResult ComprobarAdministrador(EntrecineModelContainer db, String name, ActionResult privilegiado, ActionResult erroneo)
        {
            Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(name));
            if (user != null && user.Rol >= 2)
                return privilegiado;
            else
                return erroneo;
        }

        public static ActionResult ComprobarRegistrado(EntrecineModelContainer db, String name, ActionResult privilegiado, ActionResult erroneo)
        {
            Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(name));
            if (user != null && user.Rol >= 1)
                return privilegiado;
            else
                return erroneo;
        }
    }
}