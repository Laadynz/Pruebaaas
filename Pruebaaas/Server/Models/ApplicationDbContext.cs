using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models.Entities;

namespace Pruebaaas.Server.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<ProductoClasificacion> ProductosClasificacion { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaConceptos> Conceptos { get; set; }


    }

}
