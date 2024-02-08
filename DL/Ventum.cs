using System;
using System.Collections.Generic;

namespace DL;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public DateTime? Fecha { get; set; }

    public int? IdPago { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Pago? IdPagoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
