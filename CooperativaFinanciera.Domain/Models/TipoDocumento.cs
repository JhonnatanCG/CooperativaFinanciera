using System;
using System.Collections.Generic;

namespace CooperativaFinanciera.Domain;

public partial class TipoDocumento
{
    public byte TipoDocumentoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
