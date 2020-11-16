using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBPark.Data;
using DBPark.Models.ViewModels;

namespace DBPark.Controllers
{
    public class EspacioController : Controller
    {
        // GET: Espacio
        public ActionResult Index()
        {
            List<ListEspacioViewModels> lst;
            using (DBParkEntities db = new DBParkEntities())
            {
                lst= (from d in db.Espacio
                        select new ListEspacioViewModels
                        {
                        Esp_ID=d.Esp_ID,
                        Esp_Estado=d.Esp_Estado,
                        Esp_TipVehiculo=d.Esp_TipVehiculo

                        }).ToList();

            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EspacioViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBParkEntities db = new DBParkEntities())
                    {
                        var oEspacio = new Espacio();
                        oEspacio.Esp_TipVehiculo = model.Esp_TipVehiculo;
                        oEspacio.Esp_Estado = model.Esp_Estado;

                        db.Espacio.Add(oEspacio);
                        db.SaveChanges();
                    }

                    return Redirect("~/Espacio/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            EspacioViewModels model = new EspacioViewModels();
            using (DBParkEntities db = new DBParkEntities())
            {
                var oEspacio = db.Espacio.Find(Id);
                
                model.Esp_Estado = oEspacio.Esp_Estado;
                model.Esp_TipVehiculo = oEspacio.Esp_TipVehiculo;
                model.Esp_ID = oEspacio.Esp_ID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EspacioViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBParkEntities db = new DBParkEntities())
                    {
                        var oEspacio = db.Espacio.Find(model.Esp_ID);
                        oEspacio.Esp_TipVehiculo = model.Esp_TipVehiculo;
                        oEspacio.Esp_Estado = model.Esp_Estado;

                        db.Entry(oEspacio).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Espacio/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Eliminar(int Id)
        {
            using (DBParkEntities db = new DBParkEntities())
            {

                var oEspacio = db.Espacio.Find(Id);
                db.Espacio.Remove(oEspacio);
                db.SaveChanges();
            }
            return Redirect("~/Espacio/");
        }
    }
}