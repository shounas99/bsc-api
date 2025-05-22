using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class ProductoPedido
{
    public int IdProductoPedido { get; set; }

    public int? IdProducto { get; set; }

    public int? IdPedido { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
