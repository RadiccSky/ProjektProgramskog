using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjektProgramskog.Model
{
    public partial class Partneri
    {
        public int PartnerId { get; set; }
        public string ImePartnera { get; set; } = null!;
        public string? Email { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Kategorija { get; set; }
        public decimal? Provizija { get; set; }
        public bool? Hrana { get; set; }
        public bool? CustomPartneri { get; set; }

        [JsonIgnore]
        public virtual ICollection<CustomPartneri> CustomPartneris { get; set; } = new List<CustomPartneri>();

        [JsonIgnore]
        public virtual ICollection<Cvijećarna> Cvijećarnas { get; set; } = new List<Cvijećarna>();
        [JsonIgnore]
        public virtual ICollection<Glazbenici> Glazbenicis { get; set; } = new List<Glazbenici>();
        [JsonIgnore]
        public virtual ICollection<Hrana> Hranas { get; set; } = new List<Hrana>();
        [JsonIgnore]
        public virtual ICollection<Lokacija> Lokacijas { get; set; } = new List<Lokacija>();
        [JsonIgnore]
        public virtual ICollection<Ponude> Ponudes { get; set; } = new List<Ponude>();

    
        public static JsonSerializerOptions DefaultJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true 
            };
        }
    }
}
