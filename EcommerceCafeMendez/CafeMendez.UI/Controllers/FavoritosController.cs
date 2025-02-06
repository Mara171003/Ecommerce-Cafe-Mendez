using System;
using System.Linq;
using System.Web.Mvc;
using CafeMendez.UI.dataBase;
using CafeMendez.UI.Models;

namespace CafeMendez.UI.Controllers
{
    public class FavoritosController : Controller
    {
        private Ecommerce_Cafe_MendezEntities1 db = new Ecommerce_Cafe_MendezEntities1();

        // 🚀 Agregar producto a favoritos
        [HttpPost]
        public ActionResult AgregarAFavoritos(int productoID)
        {
            int usuarioID = ObtenerUsuarioID();

            var existe = db.Favoritos.Any(f => f.UsuarioID == usuarioID && f.ProductoID == productoID);
            if (!existe)
            {
                var favorito = new CafeMendez.UI.dataBase.Favoritos
                {
                    UsuarioID = usuarioID,
                    ProductoID = productoID,
                    FechaAgregado = DateTime.Now
                };
                db.Favoritos.Add(favorito);
                db.SaveChanges();
            }

            return RedirectToAction("MisFavoritos"); // 🔹 Redirige a la vista "MisFavoritos"
        }

        // 🚀 Listar favoritos del usuario actual
        public ActionResult MisFavoritos()
        {
            int usuarioID = ObtenerUsuarioID();
            var favoritos = db.Favoritos
                              .Where(f => f.UsuarioID == usuarioID)
                              .Select(f => new FavoritoViewModel
                              {
                                  FavoritoID = f.FavoritoID,
                                  ProductoID = f.ProductoID,
                                  NombreProducto = f.Producto.Nombre,
                                  FechaAgregado = f.FechaAgregado
                              }).ToList();

            return View(favoritos);
        }

        // 🚀 Eliminar producto de favoritos
        [HttpPost]
        public ActionResult EliminarFavorito(int favoritoID)
        {
            var favorito = db.Favoritos.Find(favoritoID);
            if (favorito != null)
            {
                db.Favoritos.Remove(favorito);
                db.SaveChanges();
            }
            return RedirectToAction("MisFavoritos");
        }

        private int ObtenerUsuarioID()
        {
            return 1; // Reemplazar con el usuario autenticado real
        }
    }
}
