using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CafeMendez.UI.dataBase;
using CafeMendez.UI.Models;

namespace CafeMendez.UI.Controllers
{
    public class CarritoController : Controller
    {
        private Ecommerce_Cafe_MendezEntities1 db = new Ecommerce_Cafe_MendezEntities1();

        // ✅ ECM-011: Agregar un producto al carrito
        [HttpPost]
        public ActionResult AgregarAlCarrito(int productoID, int cantidad)
        {
            string sessionID = Session.SessionID;

            // Buscar si el usuario ya tiene un carrito en la base de datos
            var carritoEntity = db.Carritos.FirstOrDefault(c => c.SessionID == sessionID);

            if (carritoEntity == null)
            {
                // Si no tiene carrito, creamos uno nuevo
                carritoEntity = new Carritos
                {
                    SessionID = sessionID,
                    FechaCreacion = DateTime.Now
                };
                db.Carritos.Add(carritoEntity);
                db.SaveChanges();
            }

            // Buscar si el producto ya está en el carrito
            var item = db.CarritoItems.FirstOrDefault(i => i.CarritoID == carritoEntity.CarritoID && i.ProductoID == productoID);

            if (item != null)
            {
                // Si el producto ya está en el carrito, aumentamos la cantidad
                item.Cantidad += cantidad;
            }
            else
            {
                // Si no, agregamos un nuevo item al carrito
                item = new CarritoItems
                {
                    CarritoID = carritoEntity.CarritoID,
                    ProductoID = productoID,
                    Cantidad = cantidad
                };
                db.CarritoItems.Add(item);
            }

            db.SaveChanges();
            return RedirectToAction("VerCarrito");
        
    }

            // ✅ ECM-012: Actualizar la cantidad de un producto en el carrito
            [HttpPost]
        public ActionResult ActualizarCantidad(int itemID, int cantidad)
        {
            var item = db.CarritoItems.Find(itemID);
            if (item != null)
            {
                item.Cantidad = cantidad;
                db.SaveChanges();
            }
            return RedirectToAction("VerCarrito");
        }

        // ✅ ECM-014: Eliminar un producto del carrito
        [HttpPost]
        public ActionResult EliminarDelCarrito(int itemID)
        {
            var item = db.CarritoItems.Find(itemID);
            if (item != null)
            {
                db.CarritoItems.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("VerCarrito");
        }

        // ✅ ECM-015: Ver el carrito de compras
        public ActionResult VerCarrito()
        {
            string sessionID = Session.SessionID;

            // Buscar el carrito en la base de datos
            var carritoEntity = db.Carritos.Include("CarritoItems").FirstOrDefault(c => c.SessionID == sessionID);

            if (carritoEntity == null)
            {
                // Si no hay carrito, devolver un carrito vacío
                carritoEntity = new Carritos { CarritoItems = new List<CarritoItems>() };
            }

            return View(carritoEntity);
        


        // Convertir la entidad de base de datos a un modelo de aplicación
        var carritoModel = new Carrito
            {
                CarritoID = carritoEntity.CarritoID,
                SessionID = carritoEntity.SessionID,
                FechaCreacion = carritoEntity.FechaCreacion,
                Items = carritoEntity.CarritoItems.Select(i => new CarritoItem
                {
                    ItemID = i.ItemID,
                    ProductoID = i.ProductoID,
                    CarritoID = i.CarritoID,
                    Cantidad = i.Cantidad
                }).ToList()
            };

            return View(carritoModel);
        }

    }
}
