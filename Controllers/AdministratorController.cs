using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AdministratorController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdministratorController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministratorji()
    {
        return await _context.Administratorji.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Administrator>> GetAdministrator(int id)
    {
        var admin = await _context.Administratorji.FindAsync(id);
        if (admin == null) return NotFound();
        return admin;
    }

    [HttpPost]
    public async Task<ActionResult<Administrator>> PostAdministrator(Administrator admin)
    {
        _context.Administratorji.Add(admin);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAdministrator), new { id = admin.Id }, admin);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdministrator(int id, Administrator admin)
    {
        if (id != admin.Id) return BadRequest();

        _context.Entry(admin).State = EntityState.Modified;
        try { await _context.SaveChangesAsync(); }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Administratorji.Any(e => e.Id == id)) return NotFound();
            throw;
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdministrator(int id)
    {
        var admin = await _context.Administratorji.FindAsync(id);
        if (admin == null) return NotFound();

        _context.Administratorji.Remove(admin);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
