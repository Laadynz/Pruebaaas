namespace Pruebaaas.Shared.Models
{
    public class VentaConceptosDto
    {
        public decimal Cantidad { get; set; }
        public string ClaveProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
        public int ProductoId { get; set; }
    }
}
