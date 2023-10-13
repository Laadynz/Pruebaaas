using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models;
using Pruebaaas.Server.Models.Entities;
using Pruebaaas.Shared.Models;

namespace Pruebaaas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        private ProveedorDto MapearProveedorConsultaDtoDesdeProveedor(Proveedor proveedor)
        {
            return new ProveedorDto
            {
                Id = proveedor.Id,
                ClaveProveedor = proveedor.ClaveProveedor,
                Nombre = proveedor.Nombre,
                Domicilio = proveedor.Domicilio,
                Email = proveedor.Email,
                Telefono = proveedor.Telefono,
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDto>>> GetProveedores()
        {
            List<ProveedorDto> proveedoresDto = new List<ProveedorDto>();
            var proveedores = await _context.Proveedores
                .OrderBy(p => p.Nombre)
                .ToListAsync();

            foreach (Proveedor proveedor in proveedores)
            {
                proveedoresDto.Add(MapearProveedorConsultaDtoDesdeProveedor(proveedor));
            }
            return proveedoresDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProveedorDto>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(p => p.Id == id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return MapearProveedorConsultaDtoDesdeProveedor(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProveedorAgregarDto proveedorDto)
        {
            try
            {
                Proveedor proveedor = new Proveedor
                {
                    ClaveProveedor = proveedorDto.ClaveProveedor,
                    Nombre = proveedorDto.Nombre,
                    Domicilio = proveedorDto.Domicilio,
                    Email = proveedorDto.Email,
                    Telefono = proveedorDto.Telefono,
                };

                _context.Proveedores.Add(proveedor);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(ProveedorDto proveedorDto)
        {
            try
            {
                Proveedor? proveedor = await _context.Proveedores
                    .FirstOrDefaultAsync(p => p.Id == proveedorDto.Id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                proveedor.ClaveProveedor = proveedorDto.ClaveProveedor;
                proveedor.Nombre = proveedorDto.Nombre;
                proveedor.Domicilio = proveedorDto.Domicilio;
                proveedor.Email = proveedorDto.Email;
                proveedor.Telefono = proveedorDto.Telefono;

                _context.Entry(proveedor).State = EntityState.Modified;
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
                var proveedor = await _context.Proveedores
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                _context.Proveedores.Remove(proveedor);
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
