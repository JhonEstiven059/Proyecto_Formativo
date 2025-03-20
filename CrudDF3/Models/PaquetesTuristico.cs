using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class PaquetesTuristico
{
    public int IdPaquete { get; set; }

    public string NombrePaquete { get; set; } = null!;

    public string? DescripcionPaquete { get; set; }

    public decimal PrecioPaquete { get; set; }

    public bool DisponibilidadPaquete { get; set; }

    public DateOnly? FechaPaquete { get; set; }

    public string? DestinoPaquete { get; set; }

    public bool EstadoPaquete { get; set; }

    public string? TipoViajePaquete { get; set; }

    public virtual ICollection<ReservasPaquete> ReservasPaquetes { get; set; } = new List<ReservasPaquete>();
}
