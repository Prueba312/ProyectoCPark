using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Park.Models;
using Park.Controllers;
using Microsoft.Ajax.Utilities;
using Park.Models.ViewModels;

namespace Park.Controllers
{
    public class DbParkController : Controller
    {
        // GET: DbPark
        public ActionResult Index()
        {
            List<ListaUsuariosViewModels> lst;

            using (DbParkEntities db = new DbParkEntities())
            {
                 lst = (from d in db.Usuario
                           select new ListaUsuariosViewModels
                           {
                               id = d.Us_ID,
                               nombre = d.Us_Name,
                               password = d.Us_Pass,
                               fecha = d.Us_fecha,
                               correo = d.Us_Correo,
                               tipo_usuario = d.Us_Tipo,
                               telefono = d.Us_Telefono,
                           }).ToList();
            }

                return View(lst);
        }

        public ActionResult NuevoUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoUsuario( UsuarioViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbParkEntities db = new DbParkEntities())
                    {
                        var oUsuario = new Usuario();
                        oUsuario.Us_ID = model.id;
                        oUsuario.Us_Name = model.nombre;
                        oUsuario.Us_Pass = model.password;
                        oUsuario.Us_fecha = model.fecha;
                        oUsuario.Us_Correo = model.correo;
                        oUsuario.Us_Telefono = model.telefono;
                        oUsuario.Us_Tipo = model.tipo_usuario;

                        db.Usuario.Add(oUsuario);
                        db.SaveChanges();
                    }
                    return Redirect("/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}