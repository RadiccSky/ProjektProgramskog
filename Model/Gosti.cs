using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Gosti
{
    public int GostiId { get; set; }

    public int Idvjenčanja { get; set; }

    public string? Ime { get; set; }

    public int? BrojStola { get; set; }

    public string? StatusGosta { get; set; }

    public virtual Vjenčanje IdvjenčanjaNavigation { get; set; } = null!;
}
