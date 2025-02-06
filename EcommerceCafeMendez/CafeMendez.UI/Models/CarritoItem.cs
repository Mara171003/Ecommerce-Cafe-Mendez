namespace CafeMendez.UI.Models
{
    public class CarritoItem
    {
        public int ItemID { get; set; }
        public int CarritoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Carrito Carrito { get; set; }
    }
}
