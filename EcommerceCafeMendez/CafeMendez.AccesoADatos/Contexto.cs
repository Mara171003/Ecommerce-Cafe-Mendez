using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CafeMendez.AccesoADatos
{
    public class Contexto : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>().ToTable("Clientes");
            modelBuilder.Entity<Ventas>().ToTable("Ventas");
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<DetalleVentas>().ToTable("DetalleVentas");
            modelBuilder.Entity<Inventario>().ToTable("Inventario");
            modelBuilder.Entity<Categorias>().ToTable("Categorias");
        }

        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Ventas> Venta { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<DetalleVentas> DetalleVenta { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Categorias> Categoria { get; set; }
    }
}
