using System;
using System.Collections.Generic;

namespace CrudDF3.Models;

public partial class HuespedesPaquete
{
    public int IdHuespedPaquete { get; set; }

    public int IdHuesped { get; set; }

    public int IdPaquete { get; set; }

    public virtual Huespede IdHuespedNavigation { get; set; } = null!;

    public virtual PaquetesTuristico IdPaqueteNavigation { get; set; } = null!;
}
