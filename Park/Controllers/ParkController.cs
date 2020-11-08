using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class ParkController : Controller
    {
        // GET: Park
        public ActionResult Index()
        {
            List<ListParkViweModel> lst;
            using (CrudEntities db= new CrudEntities())
            {
                lst = (from d in db.Park
                           select new ListParkViweModel
                           {
                               Park_ID = d.Park_ID,
                               Park_direccion = d.Park_direccion,
                               Park_Name = d.Park_Name,
                               Park_Piso = d.Park_Piso,
                               Us_ID = d.Us_ID,
                               Park_Tarifa = d.Park_Tarifa,
                               Park_Val_Tarifa = d.Park_Val_Tarifa
                           }).ToList();
            }

            return View(lst);
        }


        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ParkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db= new CrudEntities())
                    {
                        var oPark = new Park();
                        oPark.Park_direccion = model.Park_direccion;
                        oPark.Park_Name = model.Park_Name;
                        oPark.Park_Piso = model.Park_Piso;
                        oPark.Park_Tarifa = model.Park_Tarifa;
                        oPark.Us_ID = model.Us_ID;
                        oPark.Park_Val_Tarifa = model.Park_Val_Tarifa;

                        db.Park.Add(oPark);
                        db.SaveChanges();
                    }

                    return Redirect("~/Park/");
                }

                return View(model);
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Park_ID)
        {
            ParkViewModel model = new ParkViewModel();
            using (CrudEntities db= new CrudEntities())
            {
                var oPark = db.Park.Find(Park_ID);
                model.Park_ID = oPark.Park_ID;
                model.Park_direccion = oPark.Park_direccion;
                model.Park_Name = oPark.Park_Name;
                model.Park_Piso = oPark.Park_Piso;
                model.Us_ID = oPark.Us_ID;
                model.Park_Tarifa = oPark.Park_Tarifa;
                model.Park_Val_Tarifa = oPark.Park_Val_Tarifa;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(ParkViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oPark = db.Park.Find(model.Park_ID);
                        oPark.Park_direccion = model.Park_direccion;
                        oPark.Park_Name = model.Park_Name;
                        oPark.Park_Piso = model.Park_Piso;
                        oPark.Us_ID = model.Us_ID;
                        oPark.Park_Tarifa = model.Park_Tarifa;
                        oPark.Park_Val_Tarifa = model.Park_Val_Tarifa;

                        db.Entry(oPark).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Park/");
                }

                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            using (CrudEntities db = new CrudEntities())
            {
              
                var oPark = db.Park.Find(Id);
                db.Park.Remove(oPark);
                db.SaveChanges();
            }
            return Redirect("~/Park/");
        }

    }
}