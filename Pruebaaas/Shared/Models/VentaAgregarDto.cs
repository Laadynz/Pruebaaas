namespace Pruebaaas.Shared.Models
{
    public class VentaAgregarDto
    {
        public int ClienteId { get; set; }
        public List<VentaConceptosDto> Conceptos { get; set; } = new List<VentaConceptosDto>();
    }
}
