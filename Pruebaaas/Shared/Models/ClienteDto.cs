﻿namespace Pruebaaas.Shared.Models
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public bool TieneCredito { get; set; }
    }
}
