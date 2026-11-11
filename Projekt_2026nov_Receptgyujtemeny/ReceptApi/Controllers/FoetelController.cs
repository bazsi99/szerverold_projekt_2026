using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;
using ReceptApi.Models;

namespace ReceptApi.Controllers
{
    [Route("api/foetel")]
    public class FoetelController : EtelAlapController
    {
        protected override string Tipus => "foetel";

        public FoetelController(ReceptContext db) : base(db) { }

        [HttpGet("random")]
        public async Task<ActionResult<Recept>> Random()
        {
            var mind = await Lekerdezes().ToListAsync();
            if (mind.Count == 0) return NotFound();
            return mind[new Random().Next(mind.Count)];
        }
    }
}