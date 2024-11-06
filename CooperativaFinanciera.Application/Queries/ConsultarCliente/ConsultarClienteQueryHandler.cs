using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Queries.ConsultarCliente
{
    public class ConsultarClienteQueryHandler : IRequestHandler<ConsultarClienteQuery, IEnumerable<ClienteDto>>
    {
        private readonly IClienteService _iClienteService;

        public ConsultarClienteQueryHandler(IClienteService iClienteService)
        {
            _iClienteService = iClienteService;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(ConsultarClienteQuery request, CancellationToken cancellationToken)
        {
            
            var filtro = new ConsultaClienteFiltro
            {
                Nombre = request.Nombre,
                NumeroDocumento = request.NumeroDocumento,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                MasDeUnTelefono = request.MasDeUnTelefono,
                MasDeUnaDireccion = request.MasDeUnaDireccion
            };

            
            var clientes = await _iClienteService.ConsultarClientesPorFiltro(filtro);

            return clientes;
        }
    }
}
