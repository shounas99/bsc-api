using System;
using System.Collections.Generic;

namespace bscApi.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? Nombre { get; set; }

    public string? APaterno { get; set; }

    public string? AMaterno { get; set; }

    public string? Domicilio { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FNacimiento { get; set; }

    public string? Correo { get; set; }

    public DateTime? FCreacion { get; set; }

    public DateTime? FModifico { get; set; }
    public string Contrasenia { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
