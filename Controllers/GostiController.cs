using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektProgramskog.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektProgramskog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GostiController : ControllerBase
    {
        private readonly Pi05Context _context;

        public GostiController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/Gosti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gosti>>> GetGosti()
        {
            return await _context.Gostis.ToListAsync();
        }

        // GET: api/Gosti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gosti>> GetGosti(int id)
        {
            var gosti = await _context.Gostis.FindAsync(id);

            if (gosti == null)
            {
                return NotFound();
            }

            return gosti;
        }
        // POST: api/Gosti/AddGuests
        [HttpPost("AddGuests")]
        public async Task<ActionResult<Gosti>> AddGuests([FromBody] Gosti gostis)
        {
            if (gostis.Idvjenčanja == 0)
            {
                return BadRequest("IdVjencanja is required.");
            }

            _context.Gostis.Add(gostis);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGosti), new { id = gostis.GostiId }, gostis);
        }


        // POST: api/Gosti
        [HttpPost]
        public async Task<ActionResult<Gosti>> PostGosti(Gosti gosti)
        {
            _context.Gostis.Add(gosti);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGosti), new { id = gosti.GostiId }, gosti);
        }

        // PUT: api/Gosti/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGosti(int id, Gosti gosti)
        {
            if (id != gosti.GostiId)
            {
                return BadRequest();
            }

            _context.Entry(gosti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GostiExists(id))
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

        // DELETE: api/Gosti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGosti(int id)
        {
            var gosti = await _context.Gostis.FindAsync(id);
            if (gosti == null)
            {
                return NotFound();
            }

            _context.Gostis.Remove(gosti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GostiExists(int id)
        {
            return _context.Gostis.Any(e => e.GostiId == id);
        }
    }
}
