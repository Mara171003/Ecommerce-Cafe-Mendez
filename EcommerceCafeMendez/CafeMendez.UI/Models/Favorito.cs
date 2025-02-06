using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CafeMendez.UI.dataBase;


namespace CafeMendez.UI.Models
{
    [Table("Favoritos")]
    public class Favorito
    {
        [Key]
        public int FavoritoID { get; set; }

        [Required]
        public int UsuarioID { get; set; }

        [Required]
        public int ProductoID { get; set; }

        public DateTime FechaAgregado { get; set; } = DateTime.Now;

        // Relaciones
        [ForeignKey("UsuarioID")]
        public virtual Usuarios Usuario { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Producto Producto { get; set; }
    }
}
