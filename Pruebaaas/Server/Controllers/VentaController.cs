using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models;
using Pruebaaas.Server.Models.Entities;
using Pruebaaas.Shared.Models;

namespace Pruebaaas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VentaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<VentaDto>> GetVenta(int folio)
        {
            var venta = await _context.Ventas
                .FirstOrDefaultAsync(v => v.Folio == folio);

            if (venta == null) { return NotFound(); }


            ClienteDto clienteDto = new ClienteDto()
            {
                Id = venta.ClienteId,
                RFC = venta.Cliente.RFC,
                Nombre = venta.Cliente.Nombre,
                Domicilio = venta.Cliente.Domicilio,
                Telefono = venta.Cliente.Telefono,
                TieneCredito = venta.Cliente.TieneCredito
            };

            List<VentaConceptosDto> conceptosDto = new List<VentaConceptosDto>();
            foreach (VentaConceptos concepto in venta.Conceptos)
            {
                conceptosDto.Add(new VentaConceptosDto()
                {
                    Cantidad = concepto.Cantidad,
                    ClaveProducto = concepto.ClaveProducto,
                    Descripcion = concepto.Descripcion,
                    PrecioUnitario = concepto.PrecioUnitario,
                    Descuento = concepto.Descuento,
                    Importe = concepto.Importe,
                    ProductoId = concepto.ProductoId,
                });
            }

            VentaDto ventaDto = new VentaDto()
            {
                Folio = venta.Folio,
                Fecha = venta.Fecha,
                Descuento = venta.Descuento,
                Total = venta.Total,
                Cliente = clienteDto,
                Conceptos = conceptosDto
            };

            return ventaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add(VentaAgregarDto ventaAgregarDto)
        {
            try
            {
                var folio = await _context.Folios.FirstOrDefaultAsync()
                    ?? throw new Exception("No se encontró folio");

                List<VentaConceptos> conceptos = new List<VentaConceptos>();

                foreach (VentaConceptosDto conceptoDto in ventaAgregarDto.Conceptos)
                {
                    VentaConceptos concepto = new VentaConceptos()
                    {
                        Cantidad = conceptoDto.Cantidad,
                        ClaveProducto = conceptoDto.ClaveProducto,
                        Descripcion = conceptoDto.Descripcion,
                        PrecioUnitario = conceptoDto.PrecioUnitario,
                        Descuento = conceptoDto.Descuento,
                        Importe = conceptoDto.Importe,
                        ProductoId = conceptoDto.ProductoId
                    };

                    _context.Entry(concepto).State = EntityState.Unchanged;
                    conceptos.Add(concepto);
                }


                Venta venta = new Venta()
                {
                    Folio = folio.UltimoFolio + 1,
                    Fecha = DateTime.Now,
                    ClienteId = ventaAgregarDto.ClienteId,
                    Descuento = ventaAgregarDto.Conceptos.Sum(d => d.Descuento),
                    Total = ventaAgregarDto.Conceptos.Sum(d => d.Importe),
                    Conceptos = conceptos
                };

                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
