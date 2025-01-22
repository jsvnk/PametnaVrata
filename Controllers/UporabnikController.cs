using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UporabnikController : ControllerBase
{
    private readonly AppDbContext _context;

    public UporabnikController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Uporabnik
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Uporabnik>>> GetUporabniki()
    {
        return await _context.Uporabniki.ToListAsync();
    }

    // GET: api/Uporabnik/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Uporabnik>> GetUporabnik(int id)
    {
        var uporabnik = await _context.Uporabniki.FindAsync(id);
        if (uporabnik == null) return NotFound();
        return uporabnik;
    }

    // POST: api/Uporabnik
    [HttpPost]
    public async Task<ActionResult<Uporabnik>> PostUporabnik(Uporabnik uporabnik)
    {
        _context.Uporabniki.Add(uporabnik);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUporabnik), new { id = uporabnik.Id }, uporabnik);
    }

    // PUT: api/Uporabnik/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUporabnik(int id, Uporabnik uporabnik)
    {
        if (id != uporabnik.Id) return BadRequest();

        _context.Entry(uporabnik).State = EntityState.Modified;
        try { await _context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Uporabniki.Any(e => e.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    // DELETE: api/Uporabnik/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUporabnik(int id)
    {
        var uporabnik = await _context.Uporabniki.FindAsync(id);
        if (uporabnik == null) return NotFound();

        _context.Uporabniki.Remove(uporabnik);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
