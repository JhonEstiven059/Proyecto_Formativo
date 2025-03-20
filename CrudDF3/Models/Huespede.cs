using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class Huespede
{
    public int IdHuesped { get; set; }

    public int CedulaHuesped { get; set; }

    public string NombreHuesped { get; set; } = null!;

    public string ApellidoHuesped { get; set; } = null!;

    public string CorreoHuesped { get; set; } = null!;

    public DateOnly? FechaEntradaHuesped { get; set; }

    public DateOnly? FechaSalidaHuesped { get; set; }

    public virtual ICollection<HuespedesPaquete> HuespedesPaquetes { get; set; } = new List<HuespedesPaquete>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
