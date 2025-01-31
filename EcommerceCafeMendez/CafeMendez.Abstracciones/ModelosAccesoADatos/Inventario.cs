using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.Inventario
{
    [Table("Inventario")]
    public class Inventario
    {
        public int InventarioID { get; set; }
        public int ProductoID { get; set; }
        public int ProveedorID { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
    }
}
