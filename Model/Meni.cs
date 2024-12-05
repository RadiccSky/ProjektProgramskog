using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Meni
{
    public int MeniId { get; set; }

    public int HranaId { get; set; }

    public string VrstaHrane { get; set; } = null!;

    public int? BrojSljedova { get; set; }

    public string? CustomObrok { get; set; }

    public decimal? Cijena { get; set; }

    public virtual Hrana Hrana { get; set; } = null!;
}
