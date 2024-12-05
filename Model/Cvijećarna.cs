using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Cvijećarna
{
    public int CvijećarnaId { get; set; }

    public int PartnerId { get; set; }

    public string? Ime { get; set; }

    public decimal? Cijena { get; set; }

    public string? Detalji { get; set; }

    public virtual Partneri Partner { get; set; } = null!;
}
