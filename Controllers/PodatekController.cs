using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PodatekController : ControllerBase
{
    private readonly AppDbContext _context;

    public PodatekController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Podatek>>> GetPodatki()
    {
        return await _context.Podatki.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Podatek>> GetPodatek(int id)
    {
        var podatek = await _context.Podatki.FindAsync(id);

        if (podatek == null)
        {
            return NotFound();
        }

        return podatek;
    }

    [HttpPost]
    public async Task<ActionResult<Podatek>> PostPodatek(Podatek podatek)
    {
        _context.Podatki.Add(podatek);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPodatek), new { id = podatek.Id }, podatek);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPodatek(int id, Podatek podatek)
    {
        if (id != podatek.Id)
        {
            return BadRequest();
        }

        _context.Entry(podatek).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PodatekExists(id))
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
    public async Task<IActionResult> DeletePodatek(int id)
    {
        var podatek = await _context.Podatki.FindAsync(id);
        if (podatek == null)
        {
            return NotFound();
        }

        _context.Podatki.Remove(podatek);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PodatekExists(int id)
    {
        return _context.Podatki.Any(e => e.Id == id);
    }
}
