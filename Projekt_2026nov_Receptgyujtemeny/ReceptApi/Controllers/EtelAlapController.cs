using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceptApi.Data;
using ReceptApi.Models;

namespace ReceptApi.Controllers
{
    [ApiController]
    public abstract class EtelAlapController : ControllerBase
    {
        protected readonly ReceptContext _db;
        protected abstract string Tipus { get; }

        protected EtelAlapController(ReceptContext db) { _db = db; }

        protected IQueryable<Recept> Lekerdezes()
        {
            var tipus = Tipus;
            return _db.Receptek
                .Include(r => r.Hozzavalok).ThenInclude(h => h.Hozzavalo)
                .Where(r => r.EtelTipus == tipus);
        }

        [HttpGet]
        public async Task<ActionResult<List<Recept>>> GetAll()
        {
            return await Lekerdezes().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recept>> GetOne(int id)
        {
            var r = await Lekerdezes().FirstOrDefaultAsync(x => x.Id == id);
            if (r == null) return NotFound();
            return r;
        }

        [HttpPost]
        public async Task<ActionResult<Recept>> Post(Recept r)
        {
            r.EtelTipus = Tipus;
            r.Letrehozva = DateTime.Now;
            r.Hozzavalok = null;
            _db.Receptek.Add(r);
            await _db.SaveChangesAsync();
            return r;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Recept uj)
        {
            var tipus = Tipus;
            var r = await _db.Receptek.FirstOrDefaultAsync(x => x.Id == id && x.EtelTipus == tipus);
            if (r == null) return NotFound();
            r.Nev = uj.Nev;
            r.Leiras = uj.Leiras;
            r.ElkeszitesiIdoPerc = uj.ElkeszitesiIdoPerc;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipus = Tipus;
            var r = await _db.Receptek.FirstOrDefaultAsync(x => x.Id == id && x.EtelTipus == tipus);
            if (r == null) return NotFound();

            var kapcsolatok = _db.ReceptHozzavalok.Where(x => x.ReceptId == id);
            _db.ReceptHozzavalok.RemoveRange(kapcsolatok);

            _db.Receptek.Remove(r);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("kereses")]
        public async Task<ActionResult<List<Recept>>> Kereses(string szo)
        {
            return await Lekerdezes()
                .Where(r => r.Nev.Contains(szo) || r.Hozzavalok.Any(h => h.Hozzavalo.Nev.Contains(szo)))
                .ToListAsync();
        }
    }
}