using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class GlasovniAsistentController : ControllerBase
{
    private readonly AppDbContext _context;

    public GlasovniAsistentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Glasovni_Asistent>>> GetGlasovniAsistenti()
    {
        return await _context.GlasovniAsistenti.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Glasovni_Asistent>> GetGlasovniAsistent(int id)
    {
        var asistent = await _context.GlasovniAsistenti.FindAsync(id);

        if (asistent == null)
        {
            return NotFound();
        }

        return asistent;
    }

    [HttpPost]
    public async Task<ActionResult<Glasovni_Asistent>> PostGlasovniAsistent(Glasovni_Asistent asistent)
    {
        _context.GlasovniAsistenti.Add(asistent);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGlasovniAsistent), new { id = asistent.Id }, asistent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutGlasovniAsistent(int id, Glasovni_Asistent asistent)
    {
        if (id != asistent.Id)
        {
            return BadRequest();
        }

        _context.Entry(asistent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GlasovniAsistentExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGlasovniAsistent(int id)
    {
        var asistent = await _context.GlasovniAsistenti.FindAsync(id);
        if (asistent == null)
        {
            return NotFound();
        }

        _context.GlasovniAsistenti.Remove(asistent);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GlasovniAsistentExists(int id)
    {
        return _context.GlasovniAsistenti.Any(e => e.Id == id);
    }
}
