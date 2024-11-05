using CooperativaFinanciera.Domain.Dtos;
using CooperativaFinanciera.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativaFinanciera.Application.Commands.UpdateCliente
{
    public record UpdateClienteCommand() : IRequest<bool>
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(2)]
        public string? TipoDocumento { get; set; }

        [Required]
        public long NumeroDocumento { get; set; }

        [Required]
        [StringLength(30)]
        public string? Nombres { get; set; }

        [Required]
        [StringLength(30)]
        public string? Apellido1 { get; set; }

        [StringLength(30)]
        public string? Apellido2 { get; set; }

        [Required]
        public string? Genero { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string? Email { get; set; }

        public ICollection<Direcciones>? Direcciones { get; set; }
        public ICollection<Telefono>? Telefonos { get; set; }
    }
}
