using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Domain.Dtos
{
    public class ConsultaClienteFiltro
    {
        public string? Nombre { get; set; }
        public long? NumeroDocumento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool MasDeUnTelefono { get; set; }
        public bool MasDeUnaDireccion { get; set; }
    }
}
