using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class HabitacionesServicio
{
    public int IdHabitacionServicio { get; set; }

    public int IdHabitacion { get; set; }

    public int IdServicio { get; set; }

    public virtual Habitacione IdHabitacionNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
