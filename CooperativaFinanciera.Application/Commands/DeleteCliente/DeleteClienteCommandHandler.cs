using CooperativaFinanciera.Domain;
using CooperativaFinanciera.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler:IRequestHandler<DeleteClienteCommand, bool>
    {
        private readonly IClienteService _iClienteService;

        public DeleteClienteCommandHandler(IClienteService iClienteService)
        {
            _iClienteService = iClienteService;
        }

        public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _iClienteService.DeleteCliente(request.codigo);

                if (!resultado)
                {

                    throw new Exception($"Cliente con ID {request.codigo} no encontrado.");
                }

                return true;

            }
            catch (Exception ex)
            {

                throw new Exception("Ocurrió un error al procesar la solicitud", ex);
            }
        }
    }
}
