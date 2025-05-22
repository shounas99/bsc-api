using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdPersona { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
