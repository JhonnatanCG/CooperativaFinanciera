using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Domain.Dtos
{
    public class ClienteDto
    {
        public int Codigo { get; set; }
        public string? TipoDocumento { get; set; }
        public long NumeroDocumento { get; set; }
        public string? NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int NumeroTelefonos { get; set; }
        public string? PrimeraDireccion { get; set; }
    }
}
