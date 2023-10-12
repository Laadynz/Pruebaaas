using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pruebaaas.Shared.Models
{
    public class ProveedorAgregarDto
    {
        public int ClaveProveedor { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int ProductoId { get; set; }
    }
}
