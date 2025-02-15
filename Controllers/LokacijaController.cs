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
    public class LokacijaController : ControllerBase
    {
        private readonly Pi05Context _context;

        public LokacijaController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/Lokacija
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lokacija>>> GetLokacije()
        {
            return await _context.Lokacijas.ToListAsync();
        }

        // GET: api/Lokacija/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lokacija>> GetLokacija(int id)
        {
            var lokacija = await _context.Lokacijas.FindAsync(id);

            if (lokacija == null)
            {
                return NotFound();
            }

            return lokacija;
        }

        // PUT: api/Lokacija/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokacija(int id, Lokacija lokacija)
        {
            if (id != lokacija.LokacijaId)
            {
                return BadRequest();
            }

            _context.Entry(lokacija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokacijaExists(id))
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

        // DELETE: api/Lokacija/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLokacija(int id)
        {
            var lokacija = await _context.Lokacijas.FindAsync(id);
            if (lokacija == null)
            {
                return NotFound();
            }

            _context.Lokacijas.Remove(lokacija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LokacijaExists(int id)
        {
            return _context.Lokacijas.Any(e => e.LokacijaId == id);
        }
    }
}
