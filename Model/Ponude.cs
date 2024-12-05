using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Ponude
{
    public int PonudaId { get; set; }

    public int PartnerId { get; set; }

    public int Idvjenčanja { get; set; }

    public string? Ime { get; set; }

    public decimal? Cijena { get; set; }

    public string? Detalji { get; set; }

    public virtual Vjenčanje IdvjenčanjaNavigation { get; set; } = null!;

    public virtual Partneri Partner { get; set; } = null!;
}
