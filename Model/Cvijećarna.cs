using ProjektProgramskog.Model;
using System.Text.Json.Serialization;

public partial class Cvijećarna
{
    public int CvijecarnaId { get; set; }
    public int PartnerId { get; set; }
    public string? Ime { get; set; }
    public decimal? Cijena { get; set; }
    public string? Detalji { get; set; }

    public virtual Partneri Partner { get; set; } = null!;
    [JsonIgnore] public virtual ICollection<Vjenčanje> Vjenčanjes { get; set; } = new List<Vjenčanje>(); // Dodajte ovo ako već nije prisutno
}
