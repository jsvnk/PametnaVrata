using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VrataController : ControllerBase
{
    private readonly List<Pametne_naprave> naprave = Pametne_naprave.GetTestData();

    [HttpGet]
    public IActionResult GetVrata()
    {
        // Pridobi podatke o vratih
        var vrata = naprave.FirstOrDefault(n => n.Tip == "Vrata");
        if (vrata != null)
        {
            return Ok(vrata);
        }
        return NotFound("Vrata niso bila najdena.");
    }

    [HttpPost]
    public IActionResult PostVrata(Pametne_naprave novaNaprava)
    {
        naprave.Add(novaNaprava);
        return Ok($"Dodana je bila nova naprava: {novaNaprava.Tip}");
    }
}
