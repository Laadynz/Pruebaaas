namespace Pruebaaas.Server.Models.Entities
{
    public class ProductoClasificacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
