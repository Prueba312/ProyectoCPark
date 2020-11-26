using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Park.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Park.Controllers
{
    public class RolesController : Controller
    { 
        ApplicationDbContext context;

        // GET: Roles
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            var Roles = new IdentityRole();
            return View(Roles);
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create(IdentityRole Roles)
        {
            context.Roles.Add(Roles);

            context.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}