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
                lst = (from d in db.Espacio
                       join Ocu in (from Ocu in db.Ocupacion where Ocu.Ocu_estado != true select new ListOcuViewModels
                       {
                           Ocu_ID = Ocu.Ocu_ID,
                           Us_ID = Ocu.Us_ID,
                           Esp_ID = Ocu.Esp_ID
                       }) on d.Esp_ID equals Ocu.Esp_ID into dept
                       from Oc in dept.DefaultIfEmpty()
                       join Usu in db.AspNetUsers on Oc.Us_ID equals Usu.Id into Users
                       from Us in Users.DefaultIfEmpty()
                       select new ListEspacioViewModels
                       {
                           Esp_ID = d.Esp_ID,
                           Esp_Estado = d.Esp_Estado,
                           Esp_TipVehiculo = d.Esp_TipVehiculo,
                           Esp_Eliminado = d.Esp_Eliminado,
                           Email = Us.Email

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
                        oEspacio.Esp_Eliminado = false;

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
                oEspacio.Esp_Eliminado = true;
                db.Entry(oEspacio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/Espacio/");
        }

        public ActionResult Ocupar(int Id)
        {
            EspacioViewModels model = new EspacioViewModels();
            using (DBParkEntities db = new DBParkEntities())
            {
                var oEspacio = db.Espacio.Find(Id);
                var getListUsu = db.AspNetUsers.ToList();
                SelectList list = new SelectList(getListUsu, "Id", "Email");
                ViewBag.UsuListEmail = list;

                var Ocu = db.Ocupacion.Find(oEspacio.Esp_ID);

                model.Esp_Estado = oEspacio.Esp_Estado;
                model.Esp_TipVehiculo = oEspacio.Esp_TipVehiculo;
                model.Esp_ID = oEspacio.Esp_ID;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Ocupar(EspacioViewModels model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DBParkEntities db = new DBParkEntities())
                    {
                        var oEspacio = db.Espacio.Find(model.Esp_ID);
                        oEspacio.Esp_Estado = "Ocupado";
                        db.Entry(oEspacio).State = System.Data.Entity.EntityState.Modified;

                        var Ocu = new Ocupacion();
                        Ocu.Us_ID = model.ID;
                        Ocu.Esp_ID = model.Esp_ID;
                        Ocu.Ocu_estado = false;

                        db.Ocupacion.Add(Ocu);
                        db.SaveChanges();

                    }

                    return Redirect("~/Espacio/");
                }
                else
                {
                    using (DBParkEntities db = new DBParkEntities())
                    {
                        var oEspacio = db.Espacio.Find(model.Esp_ID);
                        oEspacio.Esp_Estado = "Ocupado";
                        db.Entry(oEspacio).State = System.Data.Entity.EntityState.Modified;

                        var Ocu = new Ocupacion();
                        Ocu.Us_ID = model.ID;
                        Ocu.Esp_ID = model.Esp_ID;
                        Ocu.Ocu_estado = false;

                        db.Ocupacion.Add(Ocu);
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

        public ActionResult Liberar(int Id)
        {
            List<ListEspacioViewModels> lst;
            using (DBParkEntities db = new DBParkEntities())
            {
            lst = (from d in db.Ocupacion
                   where d.Esp_ID == Id
                   where d.Ocu_estado == false
                   select new ListEspacioViewModels
                    {
                       Ocu_ID = d.Ocu_ID,

                    }).ToList();

                var Ocu = db.Ocupacion.Find(lst[0].Ocu_ID);
                Ocu.Ocu_estado = true;
                db.Entry(Ocu).State = System.Data.Entity.EntityState.Modified;

                var oEspacio = db.Espacio.Find(Ocu.Esp_ID);
                oEspacio.Esp_Estado = "Libre";
                db.Entry(oEspacio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect("~/Espacio/");
        }
    }
}