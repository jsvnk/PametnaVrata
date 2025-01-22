using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PametneNapraveController : ControllerBase
{
    private readonly AppDbContext _context;

    public PametneNapraveController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pametne_naprave>>> GetNaprave()
    {
        return await _context.Naprave.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pametne_naprave>> GetNaprava(int id)
    {
        var naprava = await _context.Naprave.FindAsync(id);

        if (naprava == null)
        {
            return NotFound();
        }

        return naprava;
    }

    [HttpPost]
    public async Task<ActionResult<Pametne_naprave>> PostNaprava(Pametne_naprave naprava)
    {
        _context.Naprave.Add(naprava);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetNaprava), new { id = naprava.Id }, naprava);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutNaprava(int id, Pametne_naprave naprava)
    {
        if (id != naprava.Id)
        {
            return BadRequest();
        }

        _context.Entry(naprava).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NapravaExists(id))
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
    public async Task<IActionResult> DeleteNaprava(int id)
    {
        var naprava = await _context.Naprave.FindAsync(id);
        if (naprava == null)
        {
            return NotFound();
        }

        _context.Naprave.Remove(naprava);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NapravaExists(int id)
    {
        return _context.Naprave.Any(e => e.Id == id);
    }
}
