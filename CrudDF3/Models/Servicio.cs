using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Categoria { get; set; }

    public decimal Costo { get; set; }

    public bool Disponibilidad { get; set; }

    public string? Observacion { get; set; }

    public bool EstadoServicio { get; set; }

    public string? TipoServicio { get; set; }

    public virtual ICollection<HabitacionesServicio> HabitacionesServicios { get; set; } = new List<HabitacionesServicio>();

    public virtual ICollection<ReservasServicio> ReservasServicios { get; set; } = new List<ReservasServicio>();
}
