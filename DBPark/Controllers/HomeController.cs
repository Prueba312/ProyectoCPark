using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBPark.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Esta aplicacion fue desarrollada por estudiantes de la USC en el año 2020";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Puedes contactar al correo 12345@usc.edu.co";

            return View();
        }
    }
}