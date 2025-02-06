using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CafeMendez.UI.Models;
using CafeMendez.UI.dataBase;

namespace CafeMendez.UI.Controllers
{

    // [Authorize(Roles = "Admin")] // Asegúrate de tener roles configurados
    public class DescuentoController : Controller
    {
        private Ecommerce_Cafe_MendezEntities1 db = new Ecommerce_Cafe_MendezEntities1(); // Usa tu contexto EDMX

        // GET: Descuento/Listar
        public ActionResult Listar()
        {
            var descuentos = db.Descuento.ToList();
            return View(descuentos);
        }

        // GET: PromoCodes/Crear
        public ActionResult Crear()
        {
            return View();
        }

        // POST: PromoCodes/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(dataBase.Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Descuento.Add(descuento);
                db.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(descuento);
        }

        // GET: PromoCodes/Editar/{id}
        public ActionResult Editar(int id)
        {
            var descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: PromoCodes/Editar/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(dataBase.Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Listar");
            }
            return View(descuento);
        }

        // GET: PromoCodes/Eliminar/{id}
        public ActionResult Eliminar(int id)
        {
            var descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: PromoCodes/Eliminar/{id}
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminar(int id)
        {
            var descuento = db.Descuento.Find(id);
            if (descuento != null)
            {
                db.Descuento.Remove(descuento);
                db.SaveChanges();
            }
            return RedirectToAction("Listar");
        }

        // GET: PromoCodes/Detalles/{id}
        public ActionResult Detalles(int id)
        {
            var descuento = db.Descuento.Find(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }
    }
}
