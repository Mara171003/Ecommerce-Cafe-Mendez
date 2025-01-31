using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.Productos
{
    public class ProductoDTO
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int? CategoriaID { get; set; } // Para reflejar la relación con Categorias
    }

}
