using Microsoft.AspNetCore.Mvc;
using ProjektProgramskog.Model;
using Microsoft.EntityFrameworkCore;


namespace ProjektProgramskog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GlazbeniciController : ControllerBase
    {
        private readonly Pi05Context _context;

        public GlazbeniciController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/Glazbenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Glazbenici>>> GetGlazbenici()
        {
            return await _context.Glazbenicis.ToListAsync();
        }
    }
}
