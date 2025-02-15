using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjektProgramskog.Model;

public partial class Gosti
{
    public int GostiId { get; set; }

    public int Idvjenčanja { get; set; }

    public int BrojGostiju { get; set; }

    [JsonIgnore]
    public virtual Vjenčanje? IdvjenčanjaNavigation { get; set; } // Make it nullable
}
