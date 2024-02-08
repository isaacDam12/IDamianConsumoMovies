using System;
using System.Collections.Generic;

namespace DL;

public partial class Pago
{
    public int IdPago { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
