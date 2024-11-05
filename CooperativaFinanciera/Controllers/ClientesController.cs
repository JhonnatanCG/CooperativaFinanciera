using CooperativaFinanciera.Application.Commands.ClienteNuevo;
using CooperativaFinanciera.Application.Commands.UpdateCliente;
using CooperativaFinanciera.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CooperativaFinanciera.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("InsertCliente")]
        public async Task<IActionResult> InsertCliente([FromBody] ClienteNuevoCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == false)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Data = null,
                    Message = "Error al momento de insertar",
                    Errors = null,
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Data = result,
                Message = "Se agrego Tipo Formato correctamente",
                Errors = null,
            });
        }

        [HttpPost("ActualizarCliente")]
        public async Task<IActionResult> ActualizarCliente([FromBody] UpdateClienteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == false)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Data = null,
                    Message = "Error al momento de insertar",
                    Errors = null,
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Data = result,
                Message = "Se agrego Tipo Formato correctamente",
                Errors = null,
            });
        }
    }
}
