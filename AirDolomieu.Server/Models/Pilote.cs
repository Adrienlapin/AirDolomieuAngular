using System;
using System.Collections.Generic;

namespace AirDolomieu.Server;

public partial class Pilote
{
    public int Numpilote { get; set; }

    public string? Nompilote { get; set; }

    public string? Adresse { get; set; }

    public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();
}
