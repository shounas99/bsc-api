using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEstatusPedido { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioTotal { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual CatEstatusPedido? IdEstatusPedidoNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<ProductoPedido> ProductoPedidos { get; set; } = new List<ProductoPedido>();
}
