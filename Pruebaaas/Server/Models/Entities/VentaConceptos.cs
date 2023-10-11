namespace Pruebaaas.Server.Models.Entities
{
    public class VentaConceptos
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public Venta Venta { get; set; }
        public decimal Cantidad { get; set; }
        public string ClaveProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Importe { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
