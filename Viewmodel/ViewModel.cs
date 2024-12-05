using ProjektProgramskog.Model;

namespace ProjektProgramskog.WeddingDetailsViewModel
{
    public class WeddingDetailsViewModel
    {
        public IEnumerable<Partneri> Partneri { get; set; }
        public IEnumerable<Cvijećarna> Cvjećarne { get; set; }
        public IEnumerable<Glazbenici> Glazbenici { get; set; }
        public IEnumerable<Gosti> Gosti { get; set; }
        public IEnumerable<Hrana> Hrana { get; set; }
        public IEnumerable<Izvještaj> Izvještaji { get; set; }
        public IEnumerable<Lokacija> Lokacije { get; set; }
        public IEnumerable<Meni> Meni { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
        public IEnumerable<Ponude> Ponude { get; set; }
        public IEnumerable<Vjenčanje> Vjenčanja { get; set; }
    }

}
