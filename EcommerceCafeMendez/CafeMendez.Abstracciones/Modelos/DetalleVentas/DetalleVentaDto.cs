using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.DetalleVentas
{
    public class DetalleVentaDTO
    {
        public int DetalleID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
