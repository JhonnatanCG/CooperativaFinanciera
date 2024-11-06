using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Commands.DeleteCliente
{
    public record DeleteClienteCommand():IRequest<bool>
    {
        public int codigo { get; set; }
    }
}
