using System;
using System.Collections.Generic;

namespace CooperativaFinanciera.Domain;

public partial class Genero
{
    public string GeneroId { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
