using CooperativaFinanciera.Domain.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CooperativaFinanciera.Domain;

public partial class Cliente
{
    [Key]
    public int Codigo { get; set; }

    public string? TipoDocumento { get; set; }

    public long NumeroDocumento { get; set; }

    public string? Nombres { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Genero { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public ICollection<Direcciones> Direcciones { get; set; } = new List<Direcciones>();
    public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
}
