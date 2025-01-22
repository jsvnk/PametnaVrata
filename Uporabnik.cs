using System.ComponentModel.DataAnnotations;

public class Uporabnik
{
    [Key]
    public int Id { get; set; }
    public string UporabniskoIme { get; set; } = string.Empty; // Inicializacija
    public string Geslo { get; set; } = string.Empty;
    public string Vloga { get; set; } = string.Empty;

    // Statično skladišče za shranjevanje prijavljenih uporabnikov (za demonstracijo)
    private static HashSet<int> PrijavljeniUporabniki = new HashSet<int>();

    /// <summary>
    /// Prijavi uporabnika v sistem
    /// </summary>
    /// <param name="upIme">Uporabniško ime</param>
    /// <param name="geslo">Geslo</param>
    /// <returns>True, če je prijava uspešna, sicer false</returns>
    public bool PrijaviSe(string upIme, string geslo)
    {
        if (string.IsNullOrWhiteSpace(upIme) || string.IsNullOrWhiteSpace(geslo))
        {
            return false; // Neveljavno uporabniško ime ali geslo
        }

        if (upIme == UporabniskoIme && geslo == Geslo)
        {
            if (!PrijavljeniUporabniki.Contains(Id))
            {
                PrijavljeniUporabniki.Add(Id); // Dodaj uporabnika v prijavljene
                return true; // Prijava uspešna
            }
        }

        return false; // Neuspešna prijava
    }

    /// <summary>
    /// Odjavi uporabnika iz sistema
    /// </summary>
    public void OdjaviSe()
    {
        if (PrijavljeniUporabniki.Contains(Id))
        {
            PrijavljeniUporabniki.Remove(Id); // Odstrani uporabnika iz prijavljenih
        }
    }
}
