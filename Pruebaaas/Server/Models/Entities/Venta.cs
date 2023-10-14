namespace Pruebaaas.Server.Models.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<VentaConceptos> Conceptos { get; set; }
    }
}
