using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Glazbenici
{
    public int GlazbenikId { get; set; }

    public int PartnerId { get; set; }

    public string? Ime { get; set; }

    public decimal? OsnovnaCijena { get; set; }

    public decimal? CijenaPoSatu { get; set; }

    public string? SlobodniDatumi { get; set; }

    public virtual Partneri Partner { get; set; } = null!;

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    // Add this navigation property
    public virtual ICollection<Vjenčanje> Vjenčanjes { get; set; } = new List<Vjenčanje>();
}
