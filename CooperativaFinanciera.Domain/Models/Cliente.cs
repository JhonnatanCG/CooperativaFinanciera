using System;
using System.Collections.Generic;

namespace CooperativaFinanciera.Domain;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public byte TipoDocumentoId { get; set; }

    public long NumeroDocumento { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public string? GeneroId { get; set; }

   

    public DateOnly FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Direccion> Direccions { get; set; } = new List<Direccion>();

    public virtual Genero Genero { get; set; } = null!;

    public virtual ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();

    public virtual TipoDocumento TipoDocumento { get; set; } = null!;
}
