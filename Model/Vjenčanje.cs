using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Vjenčanje
{
    public int Idvjenčanja { get; set; }

    public DateOnly Datum { get; set; }

    public string? ImeKontakta { get; set; }

    public string? BrojKontakta { get; set; }

    public string? Template { get; set; }

    public string? Napomena { get; set; }

    public virtual ICollection<Gosti> Gostis { get; set; } = new List<Gosti>();

    public virtual ICollection<Izvještaj> Izvještajs { get; set; } = new List<Izvještaj>();

    public virtual ICollection<Ponude> Ponudes { get; set; } = new List<Ponude>();
}
