using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntrecineWebApp.Models;

namespace EntrecineWebApp.Controllers
{
    public class RecomendacionesController : Controller
    {
        //
        // GET: /Recomendaciones/

        public ActionResult Index()
        {
           
            return View(new RecomendacionesModel());
        }

    }
}
