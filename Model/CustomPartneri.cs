using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class CustomPartneri
{
    public int CustomPartnerId { get; set; }

    public int PartnerId { get; set; }

    public string Ime { get; set; } = null!;

    public decimal Cijena { get; set; }

    public string? Usluga { get; set; }

    public virtual Partneri Partner { get; set; } = null!;
}
