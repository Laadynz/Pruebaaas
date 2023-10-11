namespace Pruebaaas.Server.Models.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal UnidadesEnStock { get; set; }
        public int ClaveProducto { get; set; }

        public int ClasificacionId { get; set; }
        public ProductoClasificacion Clasificacion { get; set; }


        // Agrega una colección de Proveedores para representar la relación uno a muchos
        public List<Proveedor> Proveedores { get; set; }

    }

}
