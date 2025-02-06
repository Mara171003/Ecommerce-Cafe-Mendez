using System.ComponentModel.DataAnnotations;

namespace CafeMendez.UI.Models
{
    public class Producto
    {
        [Key]
        public int ProductoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Categoria { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }
    }
}
