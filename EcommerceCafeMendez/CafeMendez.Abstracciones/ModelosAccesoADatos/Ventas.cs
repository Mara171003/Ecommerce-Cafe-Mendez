using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.Ventas
{
    [Table("Ventas")]
    public class Ventas
    {
        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
