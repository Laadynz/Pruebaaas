using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models.Entities;
using Pruebaaas.Server.Models;
using Pruebaaas.Shared.Models;


namespace Pruebaaas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetProductos()
        {
            List<ProductoDto> productosDto = new List<ProductoDto>();
            var productos = await _context.Productos
                .Include(c => c.Clasificacion)
                .Include(p => p.Proveedores)
                .OrderBy(pc => pc.Nombre)
                .ToListAsync();

            foreach (Producto producto in productos)
            {
                productosDto.Add(MapearProductoDtoDesdeProducto(producto));
            }
            return productosDto;
        }

        private ProductoDto MapearProductoDtoDesdeProducto(Producto producto)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                UnidadesEnStock = producto.UnidadesEnStock,
                ClaveProducto = producto.ClaveProducto,
                Clasificacion = producto.Clasificacion.Descripcion,
                Proveedores = MapearProductoProveedorDtoDesdeProducto(producto)
            };
        }

        private List<ProveedorDto> MapearProductoProveedorDtoDesdeProducto(Producto producto)
        {
            List<ProveedorDto> proveedores = new List<ProveedorDto>();

            foreach (Proveedor proveedor in producto.Proveedores)
            {
                proveedores.Add(new ProveedorDto
                {
                    Id = proveedor.Id,
                    Nombre = proveedor.Nombre,

                });
            };
            return proveedores;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Include(c => c.Clasificacion)
                .Include(p => p.Proveedores)
                .FirstOrDefaultAsync(pc => pc.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return MapearProductoDtoDesdeProducto(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductoAgregarDto productoDto)
        {
            try
            {
                Producto producto = new Producto
                {
                    Nombre = productoDto.Nombre,
                    UnidadesEnStock = productoDto.UnidadesEnStock,
                    ClaveProducto = productoDto.ClaveProducto,
                    ClasificacionId = productoDto.ClasificacionId,
                };

                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProducto(ProductoDto producto)
        {
            try
            {
                var productos = await _context.ProductosClasificacion
                    .FirstOrDefaultAsync(pc => pc.Id == producto.Id);

                if (producto == null)
                {
                    return NotFound();
                }

                producto.Id = producto.Id;
                producto.Nombre = producto.Nombre;
                producto.UnidadesEnStock = producto.UnidadesEnStock;
                producto.ClaveProducto = producto.ClaveProducto;
                producto.ClasificacionId = producto.ClasificacionId;

                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var producto = await _context.Productos
                    .FirstOrDefaultAsync(pc => pc.Id == id);

                if (producto == null)
                {
                    return NotFound();
                }

                _context.Productos.Remove(producto);
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
