using Microsoft.AspNetCore.Mvc;
using ProjektProgramskog.Model;
using Microsoft.EntityFrameworkCore;

namespace ProjektProgramskog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var lokacije = await _context.Lokacijas.ToListAsync();
            return Ok(lokacije);
        }
    }
}
