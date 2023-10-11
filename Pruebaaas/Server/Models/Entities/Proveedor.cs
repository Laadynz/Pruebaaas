namespace Pruebaaas.Server.Models.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public int ClaveProveedor { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }


        // Agrega una propiedad para la clave externa que se relacionará con Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
