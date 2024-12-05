using System;
using System.Collections.Generic;

namespace ProjektProgramskog.Model;

public partial class Playlist
{
    public int PlaylistId { get; set; }

    public int GlazbenikId { get; set; }

    public string? ListPjesama { get; set; }

    public virtual Glazbenici Glazbenik { get; set; } = null!;
}
