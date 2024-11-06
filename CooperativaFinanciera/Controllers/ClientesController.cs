using CooperativaFinanciera.Api.Common;
using CooperativaFinanciera.Application.Commands.ClienteNuevo;
using CooperativaFinanciera.Application.Commands.DeleteCliente;
using CooperativaFinanciera.Application.Commands.UpdateCliente;
using CooperativaFinanciera.Application.Queries.ConsultarCliente;
using CooperativaFinanciera.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

        [ApiKey]
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
                Message = "Se agrego cliente correctamente",
                Errors = null,
            });
        }

        [ApiKey]
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
                    Message = "Error al momento de actualizar",
                    Errors = null,
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Data = result,
                Message = "Se actualizo cliente correctamente",
                Errors = null,
            });
        }

        [ApiKey]
        [HttpPut("EliminarCliente")]
        public async Task<IActionResult> DeleteCliente([FromBody] DeleteClienteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result == false)
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Data = null,
                    Message = "Error al momento de eliminar",
                    Errors = null,
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Data = result,
                Message = "Se elimino correctamente",
                Errors = null,
            });
        }

        [ApiKey]
        [HttpGet("ConsultaCliente")]
        public async Task<IActionResult> ConsultaCliente([FromQuery] ConsultarClienteQuery command)
        {
            var result = await _mediator.Send(command);

            if (result == null || !result.Any())
            {
                return NotFound(new ApiResponse<object>
                {
                    Success = false,
                    Data = null,
                    Message = "Consulta del cliente presento error",
                    Errors = null,
                });
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Data = result,
                Message = "Consulta exitosa",
                Errors = null,
            });
        }
    }
}
