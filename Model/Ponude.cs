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

    public string? Detalji { get; set; } // Dodatni opis ponude

    public bool JeUnaprijedDefiniran { get; set; } // True za sistemske predloške, False za prilagođene

    public string? JsonPodaci { get; set; } // Spremanje dodatnih podataka kao JSON

    public virtual Vjenčanje IdvjenčanjaNavigation { get; set; } = null!;

    public virtual Partneri Partner { get; set; } = null!;
}
