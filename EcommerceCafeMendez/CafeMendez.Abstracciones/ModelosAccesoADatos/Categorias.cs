using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.Abstracciones.Modelos.Categorias
{
    [Table("Categorias")]
    public class Categorias
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
    }
}
