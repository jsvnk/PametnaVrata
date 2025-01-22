using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Streznik
{
    [Key]
    public int Id { get; set; }
    public string Naslov { get; set; } = string.Empty; // Inicializacija
    public bool Status { get; set; }

    // Seznam uporabnikov za preverjanje (simulacija podatkov v bazi)
    private static readonly List<(string UporabniskoIme, string Geslo)> Uporabniki = new List<(string, string)>
    {
        ("Janez", "1234"),
        ("Maja", "password"),
        ("Admin", "admin123")
    };

    /// <summary>
    /// Preveri, ali so podani podatki o uporabniku pravilni.
    /// </summary>
    /// <param name="upIme">Uporabniško ime.</param>
    /// <param name="geslo">Geslo.</param>
    /// <returns>True, če so podatki pravilni, sicer false.</returns>
    public bool PreveriUporabnika(string upIme, string geslo)
    {
        if (string.IsNullOrWhiteSpace(upIme) || string.IsNullOrWhiteSpace(geslo))
        {
            Console.WriteLine("Uporabniško ime ali geslo je prazno.");
            return false;
        }

        foreach (var uporabnik in Uporabniki)
        {
            if (uporabnik.UporabniskoIme == upIme && uporabnik.Geslo == geslo)
            {
                Console.WriteLine($"Uporabnik '{upIme}' uspešno preverjen.");
                return true;
            }
        }

        Console.WriteLine($"Neuspešna prijava za uporabnika '{upIme}'.");
        return false;
    }

    /// <summary>
    /// Obdela zahtevo in vrne ustrezno sporočilo.
    /// </summary>
    /// <param name="zahteva">Zahteva, ki jo je treba obdelati.</param>
    public void ObdelajZahtevo(string zahteva)
    {
        if (string.IsNullOrWhiteSpace(zahteva))
        {
            Console.WriteLine("Prejeta zahteva je prazna.");
            return;
        }

        Console.WriteLine($"Obdelujem zahtevo: '{zahteva}'...");
        // Simulacija obdelave zahteve
        Console.WriteLine($"Zahteva '{zahteva}' uspešno obdelana.");
    }

    /// <summary>
    /// Obdela glasovni ukaz in izvrši ustrezno dejanje.
    /// </summary>
    /// <param name="ukaz">Ukaz, ki ga je treba obdelati.</param>
    public void ObdelajUkaz(string ukaz)
    {
        if (string.IsNullOrWhiteSpace(ukaz))
        {
            Console.WriteLine("Prejeti ukaz je prazen.");
            return;
        }

        Console.WriteLine($"Obdelujem ukaz: '{ukaz}'...");
        // Simulacija obdelave ukaza
        switch (ukaz.ToLower())
        {
            case "odpri vrata":
                Console.WriteLine("Vrata so odprta.");
                break;
            case "zapri vrata":
                Console.WriteLine("Vrata so zaprta.");
                break;
            case "prižgi luč":
                Console.WriteLine("Luč je prižgana.");
                break;
            case "ugasni luč":
                Console.WriteLine("Luč je ugasnjena.");
                break;
            default:
                Console.WriteLine($"Ukaz '{ukaz}' ni prepoznan.");
                break;
        }
    }
}
