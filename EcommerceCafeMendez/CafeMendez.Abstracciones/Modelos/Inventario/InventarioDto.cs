using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.Inventario
{
    public class InventarioDTO
    {
        public int InventarioID { get; set; }
        public int ProductoID { get; set; }
        public int ProveedorID { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
    }
}
