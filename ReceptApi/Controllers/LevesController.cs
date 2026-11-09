using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;
using ReceptApi.Models;

namespace ReceptApi.Controllers
{
    [ApiController]
    [Route("api/leves")]
    public class LevesController : ControllerBase
    {
        private readonly ReceptContext _db;
        public LevesController(ReceptContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<List<Leves>>> GetAll()
        {
            return await _db.Levesek.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leves>> GetOne(int id)
        {
            var l = await _db.Levesek.FindAsync(id);
            if (l == null) return NotFound();
            return l;
        }

        [HttpPost]
        public async Task<ActionResult<Leves>> Post(Leves l)
        {
            _db.Levesek.Add(l);
            await _db.SaveChangesAsync();
            return l;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Leves l)
        {
            if (id != l.Id) return BadRequest();
            _db.Entry(l).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var l = await _db.Levesek.FindAsync(id);
            if (l == null) return NotFound();
            _db.Levesek.Remove(l);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("kereses")]
        public async Task<ActionResult<List<Leves>>> Kereses(string szo)
        {
            return await _db.Levesek.Where(l => l.Name.Contains(szo) || l.Ingredients.Contains(szo)).ToListAsync();
        }
    }
}