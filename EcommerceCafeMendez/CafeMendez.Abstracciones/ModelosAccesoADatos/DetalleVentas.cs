using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.DetalleVentas
{
    [Table("DetalleVentas")]
    public class DetalleVentas
    {
        public int DetalleID { get; set; }
        public int VentaID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
