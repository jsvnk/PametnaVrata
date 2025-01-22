using System;
using System.ComponentModel.DataAnnotations;

public class Mobilna_Aplikacija
{
    [Key]
    public int Id { get; set; }
    public bool Povezava { get; set; }
    public Uporabnik StanjeUporabnika { get; set; } = new(); // Inicializacija

    /// <summary>
    /// Pošlje zahtevo strežniku, če je aplikacija povezana.
    /// </summary>
    /// <param name="ukaz">Ukaz, ki ga želimo poslati.</param>
    public void PosljiZahtevo(string ukaz)
    {
        if (!Povezava)
        {
            Console.WriteLine("Napaka: Mobilna aplikacija ni povezana.");
            return;
        }

        if (StanjeUporabnika == null)
        {
            Console.WriteLine("Napaka: Uporabnik ni prijavljen.");
            return;
        }

        // Simulacija pošiljanja zahteve
        Console.WriteLine($"Zahteva '{ukaz}' je bila poslana strežniku.");
    }

    /// <summary>
    /// Prikazuje obvestilo uporabniku.
    /// </summary>
    /// <param name="sporocilo">Sporočilo za prikaz.</param>
    public void PrikaziObvestilo(string sporocilo)
    {
        if (string.IsNullOrWhiteSpace(sporocilo))
        {
            Console.WriteLine("Napaka: Obvestilo je prazno.");
            return;
        }

        // Simulacija prikaza obvestila
        Console.WriteLine($"Obvestilo uporabniku: {sporocilo}");
    }

    /// <summary>
    /// Poveže mobilno aplikacijo z omrežjem.
    /// </summary>
    public void PoveziAplikacijo()
    {
        Povezava = true;
        Console.WriteLine("Mobilna aplikacija je povezana.");
    }

    /// <summary>
    /// Odklopi mobilno aplikacijo od omrežja.
    /// </summary>
    public void OdklopiAplikacijo()
    {
        Povezava = false;
        Console.WriteLine("Mobilna aplikacija je odklopljena.");
    }
}
