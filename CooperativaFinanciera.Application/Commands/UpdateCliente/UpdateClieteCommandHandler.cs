using CooperativaFinanciera.Application.Commands.ClienteNuevo;
using CooperativaFinanciera.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Commands.UpdateCliente
{
    internal class UpdateClieteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IClienteService _iClienteService;

        public UpdateClieteCommandHandler(IClienteService iClienteService)
        {
            _iClienteService = iClienteService;
        }
    
        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Buscar cliente por ID
                var cliente = await _iClienteService.ObtenerClientePorIdAsync(request.Codigo);
                if (cliente == null)
                {
                    throw new KeyNotFoundException("Cliente no encontrado.");
                }

                // Validar que el tipo y número de documento no estén ya registrados por otro cliente
                var existeClienteConDocumento = await _iClienteService.ExisteClienteConDocumentoAsync(
                    request.TipoDocumento!, request.NumeroDocumento);

                if (existeClienteConDocumento)
                {
                    throw new InvalidOperationException("Ya existe otro cliente con este tipo y número de documento.");
                }

                // Validar la edad y el tipo de documento
                var edad = DateTime.Today.Year - request.FechaNacimiento.Year;
                if (DateTime.Today < request.FechaNacimiento.AddYears(edad)) edad--;

                if ((edad <= 7 && request.TipoDocumento != "RC") ||
                    (edad >= 8 && edad <= 17 && request.TipoDocumento != "TI") ||
                    (edad >= 18 && request.TipoDocumento != "CC"))
                {
                    throw new InvalidOperationException("El tipo de documento no corresponde a la edad del cliente.");
                }

                // Actualizar solo los campos permitidos
                cliente.TipoDocumento = request.TipoDocumento;
                cliente.NumeroDocumento = request.NumeroDocumento;
                cliente.Nombres = request.Nombres;
                cliente.Apellido1 = request.Apellido1;
                cliente.Apellido2 = request.Apellido2;
                cliente.Genero = request.Genero;
                cliente.FechaNacimiento = request.FechaNacimiento;
                cliente.Email = request.Email;
                cliente.Direcciones = request.Direcciones ?? cliente.Direcciones;
                cliente.Telefonos = request.Telefonos ?? cliente.Telefonos;

                // Guardar cambios en la base de datos
                var resultado = await _iClienteService.UpdatCliente(cliente);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al actualizar cliente", ex);
            }
        }
    }
    
}
