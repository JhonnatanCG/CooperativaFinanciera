using CooperativaFinanciera.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CooperativaFinanciera.Application.Commands.ClienteNuevo
{
    public record ClienteNuevoCommand() : IRequest<bool>
    {
        public int ClienteId { get; set; }

        public byte TipoDocumentoId { get; set; }

        [Required]
        public long NumeroDocumento { get; set; }

        [Required, StringLength(30)]
        public string Nombres { get; set; } = null!;

        [Required, StringLength(30)]
        public string Apellido1 { get; set; } = null!;

        [StringLength(30)]
        public string? Apellido2 { get; set; }

        [Required]
        public string GeneroId { get; set; }


        public DateOnly FechaNacimiento { get; set; }

        [EmailAddress, StringLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

        public virtual Genero Genero { get; set; } = null!;

        public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();

        public virtual TipoDocumento TipoDocumento { get; set; } = null!;
    }
}
