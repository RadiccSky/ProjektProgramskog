using Microsoft.AspNetCore.Mvc;
using ProjektProgramskog.Model;
using Microsoft.EntityFrameworkCore;


namespace ProjektProgramskog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CvijecarnaController : ControllerBase
    {
        private readonly Pi05Context _context;

        public CvijecarnaController(Pi05Context context)
        {
            _context = context;
        }

        // GET: api/Glazbenici
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cvijećarna>>> GetCvijećarna()
        {
            return await _context.Cvijećarnas.ToListAsync();
        }
    }
}