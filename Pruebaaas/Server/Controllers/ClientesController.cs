﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pruebaaas.Server.Models.Entities;
using Pruebaaas.Server.Models;
using Pruebaaas.Shared.Models;

namespace Pruebaaas.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private ClienteDto MapearClienteConsultaDtoDesdeCliente(Cliente cliente)
        {
            return new ClienteDto
            {
                Id = cliente.Id,
                RFC = cliente.RFC,
                Nombre = cliente.Nombre,
                Correo = cliente.Correo,
                Domicilio = cliente.Domicilio,
                Telefono = cliente.Telefono,
                TieneCredito = cliente.TieneCredito
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> GetClientes()
        {
            List<ClienteDto> clientesDto = new List<ClienteDto>();
            var clientes = await _context.Clientes
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            foreach (Cliente cliente in clientes)
            {
                clientesDto.Add(
                    MapearClienteConsultaDtoDesdeCliente(cliente));
            }
            return clientesDto;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClienteDto>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return MapearClienteConsultaDtoDesdeCliente(cliente);
        }


        [HttpPost]
        public async Task<ActionResult> Add(ClienteAgregarDto clienteDto)
        {
            try
            {
                Cliente cliente = new Cliente
                {
                    RFC = clienteDto.RFC,
                    Nombre = clienteDto.Nombre,
                    Correo = clienteDto.Correo,
                    Domicilio = clienteDto.Domicilio,
                    Telefono = clienteDto.Telefono,
                    TieneCredito = clienteDto.TieneCredito
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                cliente.RFC = clienteDto.RFC;
                cliente.Nombre = clienteDto.Nombre;
                cliente.Correo = clienteDto.Correo;
                cliente.Domicilio = clienteDto.Domicilio;
                cliente.Telefono = clienteDto.Telefono;
                cliente.TieneCredito = clienteDto.TieneCredito;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                _context.Clientes.Remove(cliente);
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

