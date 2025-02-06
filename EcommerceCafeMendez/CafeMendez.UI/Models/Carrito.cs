using CafeMendez.UI.dataBase;
using System;
using System.Collections.Generic;

namespace CafeMendez.UI.Models
{
    public class Carrito
    {
        public int CarritoID { get; set; }
        public string UsuarioID { get; set; } // Para usuarios autenticados
        public string SessionID { get; set; } // Para usuarios no autenticados
        public DateTime FechaCreacion { get; set; }

        public virtual List<CarritoItem> Items { get; set; }
    }
}
