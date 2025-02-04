using System.Web.Mvc;
using System.Linq;
using CafeMendez.UI.dataBase; 

[Authorize(Roles = "Admin")] // Asegúrate de tener roles configurados
public class PromoCodeController : Controller
{
    private Ecommerce_Cafe_MendezEntities1 db = new Ecommerce_Cafe_MendezEntities1(); // Usa tu contexto EDMX

    // GET: PromoCodes/Listar
    public ActionResult Listar()
    {
        var promoCodes = db.PromoCodes.ToList();
        return View(promoCodes);
    }

    // GET: PromoCodes/Crear
    public ActionResult Crear()
    {
        return View();
    }

    // POST: PromoCodes/Crear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Crear(PromoCodes promoCode)
    {
        if (ModelState.IsValid)
        {
            db.PromoCodes.Add(promoCode);
            db.SaveChanges();
            return RedirectToAction("Listar");
        }
        return View(promoCode);
    }

    // GET: PromoCodes/Editar/{id}
    public ActionResult Editar(int id)
    {
        var promoCode = db.PromoCodes.Find(id);
        if (promoCode == null)
        {
            return HttpNotFound();
        }
        return View(promoCode);
    }

    // POST: PromoCodes/Editar/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Editar(PromoCodes promoCode)
    {
        if (ModelState.IsValid)
        {
            db.Entry(promoCode).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Listar");
        }
        return View(promoCode);
    }

    // GET: PromoCodes/Eliminar/{id}
    public ActionResult Eliminar(int id)
    {
        var promoCode = db.PromoCodes.Find(id);
        if (promoCode == null)
        {
            return HttpNotFound();
        }
        return View(promoCode);
    }

    // POST: PromoCodes/Eliminar/{id}
    [HttpPost, ActionName("Eliminar")]
    [ValidateAntiForgeryToken]
    public ActionResult ConfirmarEliminar(int id)
    {
        var promoCode = db.PromoCodes.Find(id);
        if (promoCode != null)
        {
            db.PromoCodes.Remove(promoCode);
            db.SaveChanges();
        }
        return RedirectToAction("Listar");
    }

    // GET: PromoCodes/Detalles/{id}
    public ActionResult Detalles(int id)
    {
        var promoCode = db.PromoCodes.Find(id);
        if (promoCode == null)
        {
            return HttpNotFound();
        }
        return View(promoCode);
    }
}

