using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models.Entities;
using Pruebaaas.Server.Models;
using Pruebaaas.Shared.Models;


namespace Pruebaaas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoClasificacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoClasificacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoClasificacionDto>>> GetProductoClasificaciones()
        {
            var productoClasificaciones = await _context.ProductosClasificacion
                .OrderBy(pc => pc.Descripcion)
                .ToListAsync();

            var productoClasificacionDtos = productoClasificaciones.Select(pc => new ProductoClasificacionDto
            {
                Id = pc.Id,
                Descripcion = pc.Descripcion,
                // Puedes incluir más propiedades si es necesario
            }).ToList();

            return productoClasificacionDtos;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoClasificacionDto>> GetProductoClasificacion(int id)
        {
            var productoClasificacion = await _context.ProductosClasificacion
                .FirstOrDefaultAsync(pc => pc.Id == id);

            if (productoClasificacion == null)
            {
                return NotFound();
            }

            var productoClasificacionDto = new ProductoClasificacionDto
            {
                Id = productoClasificacion.Id,
                Descripcion = productoClasificacion.Descripcion,
                // Puedes incluir más propiedades si es necesario
            };

            return productoClasificacionDto;
        }

        [HttpPost]
        public async Task<ActionResult> AddProductoClasificacion(ProductoClasificacionDto productoClasificacionDto)
        {
            try
            {
                var productoClasificacion = new ProductoClasificacion
                {
                    Descripcion = productoClasificacionDto.Descripcion,
                    // Puedes asignar más propiedades si es necesario
                };

                _context.ProductosClasificacion.Add(productoClasificacion);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductoClasificacion(ProductoClasificacionDto productoClasificacionDto)
        {
            try
            {
                var productoClasificacion = await _context.ProductosClasificacion
                    .FirstOrDefaultAsync(pc => pc.Id == productoClasificacionDto.Id);

                if (productoClasificacion == null)
                {
                    return NotFound();
                }

                productoClasificacion.Descripcion = productoClasificacionDto.Descripcion;
                // Actualiza más propiedades si es necesario

                _context.Entry(productoClasificacion).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductoClasificacion(int id)
        {
            try
            {
                var productoClasificacion = await _context.ProductosClasificacion
                    .FirstOrDefaultAsync(pc => pc.Id == id);

                if (productoClasificacion == null)
                {
                    return NotFound();
                }

                _context.ProductosClasificacion.Remove(productoClasificacion);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
