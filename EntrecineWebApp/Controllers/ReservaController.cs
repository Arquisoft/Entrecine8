using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class ReservaController : Controller
    {
        private EntrecineModelContainer db = new EntrecineModelContainer();


        //
        // GET: /Reserva/

        public ActionResult Crear(int id = 0)
        {

            ReservaModel model = new ReservaModel();

            //ViewBag.SesionId = new SelectList(db.SesionConjunto, "Id", "Id");
            return fillModelFor(model, id);
        }

        private ActionResult fillModelFor(ReservaModel model, int sesion)
        {
            //Seguridad
            Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(User.Identity.Name));
            if (user != null && user.Rol >= 0)
            {
                if (user.Rol == 0)
                    model.PermiteEnEfectivo = false;
                else
                    model.PermiteEnEfectivo = true;


                model.Sesion = db.SesionConjunto.FirstOrDefault(x => x.Id.Equals(sesion));

                // Elemento temporal para construir la tabla de checkboxes
                model.Ocupacion = new Butaca[model.Sesion.Sala.Filas * model.Sesion.Sala.Columnas];

                Random rdn = new Random();
                int k = 0;
                for (int i = 0; i < model.Sesion.Sala.Filas; i++)
                    for (int j = 0; j < model.Sesion.Sala.Columnas; j++)
                    {
                        model.Ocupacion[k] = new Butaca();
                        model.Ocupacion[k].Fila = i;
                        model.Ocupacion[k].Columna = j;
                        model.Ocupacion[k].Ocupada = rdn.Next(4).Equals(1);
                        k++;
                    }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        //
        // POST: /Reserva/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(ReservaModel reservamodel, string[] butacas)
        {
            if (ModelState.IsValid)
            {
                bool error = false;
                if (!reservamodel.PermiteEnEfectivo && String.IsNullOrWhiteSpace(reservamodel.TarjetaCredito))
                {
                    ModelState.AddModelError("", "No se ha especificado un número de tarjeta de crédito.");
                    error = true;
                }
                if (butacas == null || butacas.Length == 0)
                {
                    ModelState.AddModelError("", "No se han seleccionado butacas.");
                    error = true;
                }

                if (error)
                    return fillModelFor(reservamodel, reservamodel.Sesion.Id);

                // Aquí se debería validar la tarjeta de crédito

                for (int i = 0; i < butacas.Length;i++ )
                {
                    String[] butaca = butacas[i].Split(':');

                    // Buscamos el usuario
                    Usuario user = db.UsuarioConjunto.FirstOrDefault(x => x.Login.Equals(User.Identity.Name));

                    //Buscamos la sesion completa
                    Sesion sesion = db.SesionConjunto.FirstOrDefault(x => x.Id.Equals(reservamodel.Sesion.Id));

                    //Añadimos el objeto al mapeador
                    Reserva reserva = new Reserva() {Fila=Int32.Parse(butaca[0]), Columna=Int32.Parse(butaca[1]), SesionId=reservamodel.Sesion.Id, Usuario=user,};
                }


                //db.ReservaConjunto.Add(reserva);
                //db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            //ViewBag.SesionId = new SelectList(db.SesionConjunto, "Id", "Id", reserva.SesionId);
            return View(reservamodel);
        }


        //
        // GET: /Reserva/Recibo

        public ActionResult Recibo(int total)
        {
            
            ReservaModel model = new ReservaModel();
            /*
            model.Filas = 10;
            model.Columnas = 18;

            model.Ocupacion = new Butaca[model.Filas * model.Columnas];

            Random rdn = new Random();
            int k = 0;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 18; j++)
                {
                    model.Ocupacion[k] = new Butaca();
                    model.Ocupacion[k].Fila = i;
                    model.Ocupacion[k].Columna = j;
                    model.Ocupacion[k].Ocupada = rdn.Next(4).Equals(1);
                    k++;
                }

            //ViewBag.SesionId = new SelectList(db.SesionConjunto, "Id", "Id");
             */
            return View(model);
        }
    }
}