using ProjektProgramskog.Model;
using System.Text.Json.Serialization;

public partial class Vjenčanje
{
    public int Idvjenčanja { get; set; }
    public DateOnly Datum { get; set; }
    public string? ImeKontakta { get; set; }
    public string? BrojKontakta { get; set; }
    public string? Template { get; set; }
    public string? Napomena { get; set; }
    public int? LokacijaId { get; set; }
    public int? GlazbenikId { get; set; }
    public int? PlaylistId { get; set; }
    public int? PredjeloId { get; set; }
    public int? GlavnoJeloId { get; set; }
    public int? DesertId { get; set; }
    public int? CvijecarnaId { get; set; } // Dodajte ovo ako već nije prisutno

    [JsonIgnore] public virtual Lokacija? Lokacija { get; set; }
    [JsonIgnore] public virtual Glazbenici? Glazbenik { get; set; }
    [JsonIgnore] public virtual Playlist? Playlist { get; set; }
    [JsonIgnore] public virtual Hrana? Predjelo { get; set; }
    [JsonIgnore] public virtual Hrana? GlavnoJelo { get; set; }
    [JsonIgnore] public virtual Hrana? Desert { get; set; }
    [JsonIgnore] public virtual Cvijećarna? Cvijecarna { get; set; } // Dodajte ovo ako već nije prisutno
    [JsonIgnore] public virtual ICollection<Gosti> Gostis { get; set; } = new List<Gosti>();
    [JsonIgnore] public virtual ICollection<Izvještaj> Izvještajs { get; set; } = new List<Izvještaj>();
    [JsonIgnore] public virtual ICollection<Ponude> Ponudes { get; set; } = new List<Ponude>();
}
