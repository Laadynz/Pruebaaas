namespace Pruebaaas.Shared.Models
{
    public class VentaDto
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public ClienteDto Cliente { get; set; }
        public List<VentaConceptosDto> Conceptos { get; set; }
    }
}
