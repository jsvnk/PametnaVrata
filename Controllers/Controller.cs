using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VrataController : ControllerBase
{
    private static List<Pametne_naprave> naprave = Pametne_naprave.GetTestData();

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

    [HttpPut("{id}")]
    public IActionResult PutVrata(int id, Pametne_naprave posodobljenaNaprava)
    {
        var naprava = naprave.FirstOrDefault(n => n.Id == id);
        if (naprava == null)
        {
            return NotFound("Naprava ni bila najdena.");
        }

        // Posodobi podatke naprave
        naprava.Tip = posodobljenaNaprava.Tip;
        naprava.Stanje = posodobljenaNaprava.Stanje;
        naprava.PorabaEnergije = posodobljenaNaprava.PorabaEnergije;

        return Ok($"Naprava z ID-jem {id} je bila posodobljena.");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVrata(int id)
    {
        var naprava = naprave.FirstOrDefault(n => n.Id == id);
        if (naprava == null)
        {
            return NotFound("Naprava ni bila najdena.");
        }

        naprave.Remove(naprava);
        return Ok($"Naprava z ID-jem {id} je bila izbrisana.");
    }
}
