namespace Pruebaaas.Shared.Models
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal UnidadesEnStock { get; set; }
        public int ClaveProducto { get; set; }
        public int ClasificacionId { get; set; }
        public int Clasificacion { get; set; }
    }
}
