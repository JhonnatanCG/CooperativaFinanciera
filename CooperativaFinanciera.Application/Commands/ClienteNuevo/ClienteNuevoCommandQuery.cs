using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Service;
using MediatR;

namespace CooperativaFinanciera.Application.Commands.ClienteNuevo
{
    public class ClienteNuevoCommandQuery : IRequestHandler<ClienteNuevoCommand, bool>
    {
        private readonly IClienteService _iClienteService;

        public ClienteNuevoCommandQuery(IClienteService iClienteService)
        {
            _iClienteService = iClienteService;
        }

        public Task<bool> Handle(ClienteNuevoCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var clienteNuevo = new Cliente
                {
                    TipoDocumentoId = request.TipoDocumentoId,
                    NumeroDocumento = request.NumeroDocumento,
                    Nombres = request.Nombres,
                    Apellido1 = request.Apellido1,
                    Apellido2 = request.Apellido2,
                    GeneroId = request.GeneroId,
                    FechaNacimiento = request.FechaNacimiento,
                    Email = request.Email
                };

                var cliente = _iClienteService.ClienteNuevo(clienteNuevo);
                return cliente;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
