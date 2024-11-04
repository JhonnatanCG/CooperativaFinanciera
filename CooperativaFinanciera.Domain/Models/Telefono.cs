using System;
using System.Collections.Generic;

namespace CooperativaFinanciera.Domain;

public partial class Telefono
{
    public int TelefonoId { get; set; }

    public int ClienteId { get; set; }

    public long Numero { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;
}
