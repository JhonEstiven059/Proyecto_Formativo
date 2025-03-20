using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public string CodigoReserva { get; set; } = null!;

    public int IdUsuario { get; set; }

    public int IdHuesped { get; set; }

    public int IdHabitacion { get; set; }

    public DateOnly FechaInicial { get; set; }

    public DateOnly FechaFinal { get; set; }

    public int? NumeroPersonas { get; set; }

    public decimal Valor { get; set; }

    public decimal? Anticipo { get; set; }

    public DateOnly? FechaReserva { get; set; }

    public bool EstadoReserva { get; set; }

    public virtual Habitacione IdHabitacionNavigation { get; set; } = null!;

    public virtual Huespede IdHuespedNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<ReservasPaquete> ReservasPaquetes { get; set; } = new List<ReservasPaquete>();

    public virtual ICollection<ReservasServicio> ReservasServicios { get; set; } = new List<ReservasServicio>();
}
