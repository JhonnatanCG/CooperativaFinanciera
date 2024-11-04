using System;
using System.Collections.Generic;

namespace CooperativaFinanciera.Domain;

public partial class Direccion
{
    public int DireccionId { get; set; }

    public int ClienteId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;
}
