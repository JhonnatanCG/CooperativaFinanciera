using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Dtos;
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

        public async Task<bool> Handle(ClienteNuevoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!Enum.IsDefined(typeof(Generos), request.Genero!))
                {
                    throw new ArgumentException("El valor del género no es válido. Debe ser 'M' o 'F'.");
                }

                var edad = DateTime.Today.Year - request.FechaNacimiento.Year;
                if (DateTime.Today < request.FechaNacimiento.AddYears(edad)) edad--;

                if ((edad <= 7 && request.TipoDocumento != "RC") ||
                    (edad >= 8 && edad <= 17 && request.TipoDocumento != "TI") ||
                    (edad >= 18 && request.TipoDocumento != "CC"))
                {
                    throw new Exception($"El tipo de documento {request.TipoDocumento} no corresponde a la edad del cliente.");
                    
                }

                var existeCliente = await _iClienteService.ExisteClienteConDocumentoAsync(
                    request.TipoDocumento!, request.NumeroDocumento!);

                if (existeCliente)
                {
                    throw new InvalidOperationException("Ya existe un cliente con este tipo y número de documento.");
                }

                var clienteNuevo = new Cliente
                {

                    TipoDocumento = request.TipoDocumento,
                    NumeroDocumento = request.NumeroDocumento,
                    Nombres = request.Nombres,
                    Apellido1 = request.Apellido1,
                    Apellido2 = request.Apellido2,
                    Genero = request.Genero,
                    FechaNacimiento = request.FechaNacimiento,
                    Email = request.Email,
                    Direcciones = request.Direcciones,
                    Telefonos = request.Telefonos
                };

                var resultado = await _iClienteService.ClienteNuevo(clienteNuevo);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al procesar la solicitud", ex);
            }
        }
    }
}
