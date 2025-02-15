using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektProgramskog.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjektProgramskog.Controllers
{
  

    [ApiController]
    [Route("api/[controller]")]
    public class VjencanjeController : ControllerBase
    {
        private readonly Pi05Context _context;

        public VjencanjeController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/Vjencanje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vjenčanje>>> GetVjenčanja()
        {
            var vjenčanja = await _context.Vjenčanjes
                .Include(v => v.Gostis) // Ensure guests are included
                .Include(v => v.Lokacija) // Ensure location is included
                .Include(v => v.Glazbenik) // Ensure musician is included
                .ThenInclude(g => g.Playlists) // Ensure playlists are included
                .Include(v => v.Cvijecarna)
                .ToListAsync();

            var result = vjenčanja.Select(v => new
            {
                v.Idvjenčanja,
                v.ImeKontakta,
                v.Datum,
                v.LokacijaId,
                LokacijaIme = v.Lokacija?.Ime, // Use null-conditional operator
                v.Napomena,
                v.BrojKontakta,
                Gostis = v.Gostis.Select(g => new { g.BrojGostiju }),
                Glazbenik = v.Glazbenik != null ? new
                {
                    v.Glazbenik.GlazbenikId,
                    v.Glazbenik.Ime,
                    Playlists = v.Glazbenik.Playlists.Select(p => new { p.PlaylistId, p.ListPjesama })
                } : null,
                v.PredjeloId,
                v.GlavnoJeloId,
                v.DesertId,
                v.CvijecarnaId,
                CvijecarnaIme = v.Cvijecarna?.Ime, // Add CvijecarnaIme to the result
                v.PlaylistId // Add PlaylistId to the result
            });

            // Log the result for debugging
            Console.WriteLine(JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true }));

            return Ok(result);
        }



        // GET: api/Vjencanje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vjenčanje>> GetVjencanje(int id)
        {
            var vjencanje = await _context.Vjenčanjes.FindAsync(id);

            if (vjencanje == null)
            {
                return NotFound();
            }

            return vjencanje;
        }
      


        // POST: api/Vjencanje
        [HttpPost]
        public async Task<IActionResult> CreateVjencanje([FromBody] Vjenčanje vjencanje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the LokacijaId to the first Lokacija if not provided
            if (vjencanje.LokacijaId == null)
            {
                var firstLokacija = await _context.Lokacijas.FirstOrDefaultAsync();
                if (firstLokacija != null)
                {
                    vjencanje.LokacijaId = firstLokacija.LokacijaId;
                }
            }

            _context.Vjenčanjes.Add(vjencanje);
            await _context.SaveChangesAsync();

            // Create a new Gosti entry with the newly created Idvjenčanja
            var gosti = new Gosti
            {
                Idvjenčanja = vjencanje.Idvjenčanja,
                BrojGostiju = 0 // Initialize with 0 or any default value
            };

            _context.Gostis.Add(gosti);
            await _context.SaveChangesAsync();

            // Add the new Gosti entry to the Gostis collection of the Vjenčanje
            vjencanje.Gostis.Add(gosti);
            await _context.SaveChangesAsync();

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            return CreatedAtAction("GetVjencanje", new { id = vjencanje.Idvjenčanja }, JsonSerializer.Serialize(vjencanje, options));
        }

        // PUT: api/Vjencanje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVjencanje(int id, Vjenčanje vjencanje)
        {
            if (id != vjencanje.Idvjenčanja)
            {
                return BadRequest();
            }

            _context.Entry(vjencanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Update Gosti records
                var existingGosti = _context.Gostis.Where(g => g.Idvjenčanja == id).ToList();
                _context.Gostis.RemoveRange(existingGosti);
                if (vjencanje.Gostis != null)
                {
                    foreach (var BrojGostiju in vjencanje.Gostis)
                    {
                        BrojGostiju.Idvjenčanja = vjencanje.Idvjenčanja;
                        _context.Gostis.Add(BrojGostiju);
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VjencanjeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpGet("last")]
        public async Task<ActionResult<Vjenčanje>> GetLastVjencanje()
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }
            return lastVjencanje;
        }

        // PUT: api/Vjencanje/last/gosti
        [HttpPut("last/gosti")]
        public async Task<IActionResult> UpdateLastVjencanjeGosti([FromBody] Gosti gosti)
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }

            // Find the existing Gosti entry for the last Vjenčanje
            var existingGosti = await _context.Gostis.FirstOrDefaultAsync(g => g.Idvjenčanja == lastVjencanje.Idvjenčanja);
            if (existingGosti != null)
            {
                existingGosti.BrojGostiju = gosti.BrojGostiju;
                _context.Entry(existingGosti).State = EntityState.Modified;
            }
            else
            {
                gosti.Idvjenčanja = lastVjencanje.Idvjenčanja;
                gosti.IdvjenčanjaNavigation = lastVjencanje; // Set the navigation property
                _context.Gostis.Add(gosti);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("last/glazbenik")]
        public async Task<IActionResult> UpdateLastVjencanjeGlazbenik([FromBody] GlazbenikUpdateDto glazbenikUpdateDto)
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }

            lastVjencanje.GlazbenikId = glazbenikUpdateDto.GlazbenikId;
            lastVjencanje.PlaylistId = glazbenikUpdateDto.PlaylistId; // Ensure PlaylistId is updated
            _context.Entry(lastVjencanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VjencanjeExists(lastVjencanje.Idvjenčanja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public class GlazbenikUpdateDto
        {
            public int GlazbenikId { get; set; }
            public int PlaylistId { get; set; }
        }

          [HttpPut("last/cvijecarna")]
        public async Task<IActionResult> UpdateLastVjencanjeCvijecarna([FromBody] CvijecarnaUpdateDto cvijecarnaUpdateDto)
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }

            lastVjencanje.CvijecarnaId = cvijecarnaUpdateDto.CvijecarnaId;
            _context.Entry(lastVjencanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VjencanjeExists(lastVjencanje.Idvjenčanja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public class CvijecarnaUpdateDto
        {
            public int CvijecarnaId { get; set; }
        }
        [HttpPut("last/lokacija")]
        public async Task<IActionResult> UpdateLastVjencanjeLokacija([FromBody] LokacijaUpdateDto lokacijaUpdateDto)
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }

            lastVjencanje.LokacijaId = lokacijaUpdateDto.LokacijaId;
            _context.Entry(lastVjencanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VjencanjeExists(lastVjencanje.Idvjenčanja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public class LokacijaUpdateDto
        {
            public int LokacijaId { get; set; }
        }

        [HttpPut("last/hrana")]
        public async Task<IActionResult> UpdateLastVjencanjeHrana([FromBody] HranaUpdateDto hranaUpdateDto)
        {
            var lastVjencanje = await _context.Vjenčanjes.OrderByDescending(v => v.Idvjenčanja).FirstOrDefaultAsync();
            if (lastVjencanje == null)
            {
                return NotFound();
            }

            lastVjencanje.PredjeloId = hranaUpdateDto.PredjeloId;
            lastVjencanje.GlavnoJeloId = hranaUpdateDto.GlavnoJeloId;
            lastVjencanje.DesertId = hranaUpdateDto.DesertId;
            _context.Entry(lastVjencanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VjencanjeExists(lastVjencanje.Idvjenčanja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        public class HranaUpdateDto
        {
            public int PredjeloId { get; set; }
            public int GlavnoJeloId { get; set; }
            public int DesertId { get; set; }
        }

        // DELETE: api/Vjencanje/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVjencanje(int id)
        {
            var vjencanje = await _context.Vjenčanjes.FindAsync(id);
            if (vjencanje == null)
            {
                return NotFound();
            }

            _context.Vjenčanjes.Remove(vjencanje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VjencanjeExists(int id)
        {
            return _context.Vjenčanjes.Any(e => e.Idvjenčanja == id);
        }
    }
}
