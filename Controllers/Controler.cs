using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VrataController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVrata()
    {
        var vrata = new Pametne_naprave
        {
            Tip = "Vrata",
            Stanje = true,
            PorabaEnergije = 0.12
        };
        return Ok(vrata);
    }

    [HttpPost]
    public IActionResult PostVrata(Pametne_naprave vrata)
    {
        return Ok($"Vrata {vrata.Tip} so bila posodobljena.");
    }
}
