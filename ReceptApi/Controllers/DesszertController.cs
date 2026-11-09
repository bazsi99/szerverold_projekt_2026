using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;
using ReceptApi.Models;

namespace ReceptApi.Controllers
{
    [ApiController]
    [Route("api/desszert")]
    public class DesszertController : ControllerBase
    {
        private readonly ReceptContext _db;
        public DesszertController(ReceptContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<List<Desszert>>> GetAll()
        {
            return await _db.Desszertek.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Desszert>> GetOne(int id)
        {
            var d = await _db.Desszertek.FindAsync(id);
            if (d == null) return NotFound();
            return d;
        }

        [HttpPost]
        public async Task<ActionResult<Desszert>> Post(Desszert d)
        {
            _db.Desszertek.Add(d);
            await _db.SaveChangesAsync();
            return d;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Desszert d)
        {
            if (id != d.Id) return BadRequest();
            _db.Entry(d).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var d = await _db.Desszertek.FindAsync(id);
            if (d == null) return NotFound();
            _db.Desszertek.Remove(d);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("kereses")]
        public async Task<ActionResult<List<Desszert>>> Kereses(string szo)
        {
            return await _db.Desszertek.Where(d => d.Name.Contains(szo) || d.Ingredients.Contains(szo)).ToListAsync();
        }
    }
}
