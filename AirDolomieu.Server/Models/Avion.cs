using System;
using System.Collections.Generic;

namespace AirDolomieu.Server;

public partial class Avion
{
    public int Numavion { get; set; }

    public string? Nomavion { get; set; }

    public int? Capacite { get; set; }

    public string Localisation { get; set; } = null!;

    public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();
}
