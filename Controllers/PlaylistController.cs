using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektProgramskog.Model;
using System.Linq;

namespace ProjektProgramskog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class PlaylistController : ControllerBase
    {
        private readonly Pi05Context _context;

        public PlaylistController(Pi05Context context)
        {
            _context = context;
        }

        // Dohvat svih playlista
        [HttpGet]
        public ActionResult<IEnumerable<Playlist>> GetPlaylists()
        {
            var playlists = _context.Playlists.ToList();
            return Ok(playlists);
        }


        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            _context.Playlists.Add(playlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.PlaylistId }, playlist);
        }
        // Dohvat pojedine playliste po ID-u
        [HttpGet("{id}")]
        public ActionResult<Playlist> GetPlaylist(int id)
        {
            var playlist = _context.Playlists.FirstOrDefault(p => p.PlaylistId == id);

            if (playlist == null)
            {
                return NotFound();
            }

            return Ok(playlist);
        }

        // Dohvat playlisti prema ID-u glazbenika
        [HttpGet("musician/{glazbenikId}")]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylistsByMusician(int glazbenikId)
        {
            var playlists = await _context.Playlists
                .Where(p => p.GlazbenikId == glazbenikId)
                .ToListAsync();

            if (playlists == null || !playlists.Any())
            {
                return NotFound("No playlists found for this musician.");
            }

            return Ok(playlists);
        }

        
    }
}
