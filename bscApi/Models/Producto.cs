using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdCategoriaProducto { get; set; }

    public string? Producto1 { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public virtual CategoriaProducto? IdCategoriaProductoNavigation { get; set; }

    public virtual ICollection<ProductoPedido> ProductoPedidos { get; set; } = new List<ProductoPedido>();
}
