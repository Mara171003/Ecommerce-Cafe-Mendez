using System;

namespace CafeMendez.UI.Models
{
    public class FavoritoViewModel
    {
        public int FavoritoID { get; set; }
        public int ProductoID { get; set; }
        public string NombreProducto { get; set; }
        public DateTime FechaAgregado { get; set; }
    }
}
