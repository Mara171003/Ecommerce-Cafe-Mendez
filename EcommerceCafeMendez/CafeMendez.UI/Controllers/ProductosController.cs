using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeMendez.UI.dataBase;
using CafeMendez.UI.Models;// Asegúrate de cambiar esto por el namespace de tu proyecto

namespace CafeMendez.UI.Controllers
{
    public class ProductosController : Controller
    {
        private Ecommerce_Cafe_MendezEntities1 db = new Ecommerce_Cafe_MendezEntities1(); // Contexto EDMX

        // GET: Productos/Listar
        public ActionResult Listar(string searchTerm, string categoria)
        {
            var productos = db.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchTerm));
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                productos = productos.Where(p => p.Categoria == categoria);
            }

            // Obtener las categorías únicas desde la base de datos
            var categorias = db.Productos.Select(p => p.Categoria).Distinct().ToList();

            // Pasar categorías a la vista usando ViewBag
            ViewBag.Categorias = categorias;

            // Mapear a Models.Producto
            var productosModel = productos.Select(p => new CafeMendez.UI.Models.Producto
            {
                ProductoID = p.ProductoID,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Precio = p.Precio
            }).ToList();

            return View(productosModel); // ✅ Ahora la vista recibe el tipo correcto
        }

    

    // GET: Productos/Detalles/{id}
    public ActionResult Detalles(int id)
        {
            var producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/AgregarAlCarrito
        [HttpPost]
        public ActionResult AgregarAlCarrito(int productoID, int cantidad)
        {
            string sessionID = Session.SessionID; // Obtener la sesión del usuario

            // Obtener o crear el carrito
            var carrito = db.Carritos.FirstOrDefault(c => c.SessionID == sessionID);
            if (carrito == null)
            {
                carrito = new Carritos
                {
                    SessionID = sessionID,
                    FechaCreacion = DateTime.Now
                };
                db.Carritos.Add(carrito);
                db.SaveChanges();
            }

            // Agregar el producto al carrito
            var carritoItem = db.CarritoItems.FirstOrDefault(ci => ci.CarritoID == carrito.CarritoID && ci.ProductoID == productoID);
            if (carritoItem != null)
            {
                carritoItem.Cantidad += cantidad;
            }
            else
            {
                db.CarritoItems.Add(new CarritoItems
                {
                    CarritoID = carrito.CarritoID,
                    ProductoID = productoID,
                    Cantidad = cantidad
                });
            }

            db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}