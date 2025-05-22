using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class Perfile
{
    public int IdPerfil { get; set; }

    public string? Perfil { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
