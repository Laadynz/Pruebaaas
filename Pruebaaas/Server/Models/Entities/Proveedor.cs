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

        public List<Producto> Productos { get; set; }

    }
}
