using CooperativaFinanciera.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Queries.ConsultarCliente
{
    public record ConsultarClienteQuery : IRequest<IEnumerable<ClienteDto>>
    {
        public string? Nombre { get; set; }
        public long? NumeroDocumento { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public bool MasDeUnTelefono { get; set; } = false;
        public bool MasDeUnaDireccion { get; set; } = false;
    }
    
}
