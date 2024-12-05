using Microsoft.AspNetCore.Mvc;
using ProjektProgramskog.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ProjektProgramskog.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class WeddingController : ControllerBase 
    {
        private readonly Pi05Context _context;


        public WeddingController(Pi05Context context)
        {
            _context = context;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            var viewModel = new WeddingDetailsViewModel.WeddingDetailsViewModel
            {
                Partneri = await _context.Partneris.ToListAsync(),
                Cvjećarne = await _context.Cvijećarnas.ToListAsync(),
                Glazbenici = await _context.Glazbenicis.ToListAsync(),
                Gosti = await _context.Gostis.ToListAsync(),
                Izvještaji = await _context.Izvještajs.ToListAsync(),
                Lokacije = await _context.Lokacijas.ToListAsync(),
                Playlists = await _context.Playlists.ToListAsync(),
                Ponude = await _context.Ponudes.ToListAsync(),
                Vjenčanja = await _context.Vjenčanjes.ToListAsync()
            };

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                MaxDepth = 32,
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(viewModel, options);
            return Ok(JsonSerializer.Serialize(viewModel, options));
        }
    }
}
