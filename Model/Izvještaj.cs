using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Izvještaj
{
    public int IzvještajId { get; set; }

    public int Idvjenčanja { get; set; }

    public string? TipIzvještaja { get; set; }

    public string? Sadržaj { get; set; }

    public virtual Vjenčanje IdvjenčanjaNavigation { get; set; } = null!;
}
