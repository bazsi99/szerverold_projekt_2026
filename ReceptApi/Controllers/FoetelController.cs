using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;
using ReceptApi.Models;

namespace ReceptApi.Controllers
{
    [ApiController]
    [Route("api/foetel")]
    public class FoetelController : ControllerBase
    {
        private readonly ReceptContext _db;
        public FoetelController(ReceptContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<List<Foetel>>> GetAll()
        {
            return await _db.Foetelek.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Foetel>> GetOne(int id)
        {
            var f = await _db.Foetelek.FindAsync(id);
            if (f == null) return NotFound();
            return f;
        }

        [HttpPost]
        public async Task<ActionResult<Foetel>> Post(Foetel f)
        {
            _db.Foetelek.Add(f);
            await _db.SaveChangesAsync();
            return f;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Foetel f)
        {
            if (id != f.Id) return BadRequest();
            _db.Entry(f).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var f = await _db.Foetelek.FindAsync(id);
            if (f == null) return NotFound();
            _db.Foetelek.Remove(f);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("kereses")]
        public async Task<ActionResult<List<Foetel>>> Kereses(string szo)
        {
            return await _db.Foetelek.Where(f => f.Name.Contains(szo) || f.Ingredients.Contains(szo)).ToListAsync();
        }

        [HttpGet("random")]
        public async Task<ActionResult<Foetel>> Random()
        {
            var mind = await _db.Foetelek.ToListAsync();
            if (mind.Count == 0) return NotFound();
            return mind[new Random().Next(mind.Count)];
        }
    }
}