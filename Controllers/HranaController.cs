// HranaController.cs
using Microsoft.AspNetCore.Mvc;
using ProjektProgramskog.Model;
using System.Collections.Generic;
using System.Linq;

namespace ProjektProgramskog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HranaController : ControllerBase
    {
        private readonly Pi05Context _context;

        public HranaController(Pi05Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hrana>> GetHrana()
        {
            var predjela = _context.Hranas.Where(h => h.TipHrane == "Predjelo").ToList();
            var glavnoJelo = _context.Hranas.Where(h => h.TipHrane == "Glavno jelo").ToList();
            var deserti = _context.Hranas.Where(h => h.TipHrane == "Desert").ToList();

            return Ok(new
            {
                Predjelo = predjela,
                GlavnoJelo = glavnoJelo,
                Desert = deserti
            });
        }

    }
}
