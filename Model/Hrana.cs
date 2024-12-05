using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Hrana
{
    public int HranaId { get; set; }

    public int PartnerId { get; set; }

    public string TipHrane { get; set; } = null!;

    public string Naziv { get; set; } = null!;

    public decimal? CijenaPoOsobi { get; set; }

    public string? Detalji { get; set; }

    public virtual ICollection<Meni> Menis { get; set; } = new List<Meni>();

    public virtual Partneri Partner { get; set; } = null!;
}
