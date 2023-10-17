namespace Pruebaaas.Shared.Models
{
    public class ProductoAgregarDto
    {
        public string Nombre { get; set; }
        public decimal UnidadesEnStock { get; set; }
        public int ClaveProducto { get; set; }
        public int ClasificacionId { get; set; }
        public decimal PrecioUnitario { get; set; }

        public List<ProveedorDto> Proveedores { get; set; } = new List<ProveedorDto>();

    }
}
