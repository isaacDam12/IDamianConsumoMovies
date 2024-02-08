using System;
using System.Collections.Generic;

namespace DL;

public partial class DetalleVentum
{
    public int IdDetalle { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}
