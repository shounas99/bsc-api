using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class CatEstatusPedido
{
    public int IdEstatusPedidos { get; set; }

    public string? EstatusPedidos { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
