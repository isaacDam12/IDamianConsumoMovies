using System;
using System.Collections.Generic;

namespace DL;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdProveedor { get; set; }

    public byte[]? Imagen { get; set; }

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
