using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjektProgramskog.Model;

public partial class Lokacija
{
    public int LokacijaId { get; set; }

    public int PartnerId { get; set; }

    public string? Ime { get; set; }

    public decimal? CijenaPoDanu { get; set; }

    [JsonIgnore] public virtual Partneri Partner { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<Vjenčanje> Vjenčanjes { get; set; } = new List<Vjenčanje>(); // Add this property
}
