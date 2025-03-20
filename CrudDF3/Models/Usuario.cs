using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int CedulaUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ApellidoUsuario { get; set; } = null!;

    public string CorreoUsuario { get; set; } = null!;

    public string ContraseñaUsuario { get; set; } = null!;

    public bool EstadoUsuario { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public int? IdRolUsuarios { get; set; }

    public virtual Role? IdRolUsuariosNavigation { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
