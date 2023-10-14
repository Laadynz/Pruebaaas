﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models.Entities;

namespace Pruebaaas.Server.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
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
        public DbSet<Folio> Folios { get; set; }

    }

}
