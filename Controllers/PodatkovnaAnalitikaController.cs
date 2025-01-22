using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PodatkovnaAnalitikaController : ControllerBase
{
    private readonly AppDbContext _context;

    public PodatkovnaAnalitikaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Podatkovna_Analitika>>> GetPodatkovneAnalize()
    {
        return await _context.PodatkovneAnalize.Include(p => p.ZgodovinaPorabe).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Podatkovna_Analitika>> GetPodatkovnaAnalitika(int id)
    {
        var analiza = await _context.PodatkovneAnalize.Include(p => p.ZgodovinaPorabe).FirstOrDefaultAsync(p => p.Id == id);

        if (analiza == null)
        {
            return NotFound();
        }

        return analiza;
    }

    [HttpPost]
    public async Task<ActionResult<Podatkovna_Analitika>> PostPodatkovnaAnalitika(Podatkovna_Analitika analiza)
    {
        _context.PodatkovneAnalize.Add(analiza);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPodatkovnaAnalitika), new { id = analiza.Id }, analiza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPodatkovnaAnalitika(int id, Podatkovna_Analitika analiza)
    {
        if (id != analiza.Id)
        {
            return BadRequest();
        }

        _context.Entry(analiza).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PodatkovnaAnalitikaExists(id))
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
    public async Task<IActionResult> DeletePodatkovnaAnalitika(int id)
    {
        var analiza = await _context.PodatkovneAnalize.FindAsync(id);
        if (analiza == null)
        {
            return NotFound();
        }

        _context.PodatkovneAnalize.Remove(analiza);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PodatkovnaAnalitikaExists(int id)
    {
        return _context.PodatkovneAnalize.Any(e => e.Id == id);
    }
}
