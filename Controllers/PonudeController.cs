using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektProgramskog.Model;
using ProjektProgramskog.WeddingDetailsViewModel;

namespace ProjektProgramskog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PonudeController : ControllerBase
    {
        private readonly Pi05Context _context;

        public PonudeController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/ponude
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ponude>>> GetPonude()
        {
            return await _context.Ponudes.ToListAsync();
        }

        // GET: api/ponude/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ponude>> GetPonuda(int id)
        {
            var ponuda = await _context.Ponudes.FindAsync(id);

            if (ponuda == null)
            {
                return NotFound();
            }

            return ponuda;
        }

        // POST: api/ponude
        [HttpPost]
        public async Task<ActionResult<Ponude>> PostPonuda(Ponude ponuda)
        {
            ponuda.JeUnaprijedDefiniran = false; // Ako želite označiti kao prilagođeni predložak

            _context.Ponudes.Add(ponuda);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPonuda), new { id = ponuda.PonudaId }, ponuda);
        }

        // PUT: api/ponude/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPonuda(int id, Ponude ponuda)
        {
            if (id != ponuda.PonudaId)
            {
                return BadRequest();
            }

            _context.Entry(ponuda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PonudaExists(id))
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

        // DELETE: api/ponude/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePonuda(int id)
        {
            var ponuda = await _context.Ponudes.FindAsync(id);
            if (ponuda == null)
            {
                return NotFound();
            }

            _context.Ponudes.Remove(ponuda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PonudaExists(int id)
        {
            return _context.Ponudes.Any(e => e.PonudaId == id);
        }
    }
}
