using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class CategoriaProducto
{
    public int IdCategoriaProducto { get; set; }

    public string? CategoriaProducto1 { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
