namespace Pruebaaas.Shared.Models
{
    public class VentaConceptosDto
    {
        public decimal Cantidad { get; set; } = 0.00m;
        public string ClaveProducto { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; } = 0.00m;
        public decimal Descuento { get; set; } = 0.00m;
        public decimal Importe { get; set; } = 0.00m;
        public int ProductoId { get; set; } = 0;
    }
}
