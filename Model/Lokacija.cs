using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Lokacija
{
    public int LokacijaId { get; set; }

    public int PartnerId { get; set; }

    public string? Ime { get; set; }

    public decimal? CijenaPoDanu { get; set; }

    public bool? Catering { get; set; }

    public virtual Partneri Partner { get; set; } = null!;
}
