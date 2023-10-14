using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebaaas.Shared.Models
{
    public class VentaAgregarDto
    {
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }
        public int ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
