using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Glasovni_Asistent
{
    [Key]
    public int Id { get; set; }
    public string Ukaz { get; set; } = string.Empty; // Inicializacija
    public bool Stanje { get; set; }
    // Seznam podprtih ukazov
    private static readonly List<string> PodprtiUkazi = new List<string>
    {
        "odpri vrata",
        "zapri vrata",
        "prižgi luč",
        "ugasni luč",
        "nastavi temperaturo"
    };

    /// <summary>
    /// Preveri, ali glasovni ukaz ustreza podprtim ukazom.
    /// </summary>
    /// <param name="ukaz">Glasovni ukaz.</param>
    /// <returns>True, če ukaz obstaja, sicer false.</returns>
    public bool PrepoznaUkaz(string ukaz)
    {
        if (string.IsNullOrWhiteSpace(ukaz))
        {
            Console.WriteLine("Ukaz je prazen ali neveljaven.");
            return false;
        }

        if (PodprtiUkazi.Contains(ukaz.ToLower()))
        {
            Console.WriteLine($"Ukaz '{ukaz}' je prepoznan.");
            return true;
        }

        Console.WriteLine($"Ukaz '{ukaz}' ni prepoznan.");
        return false;
    }

    /// <summary>
    /// Izvede glasovni ukaz, če je prepoznan.
    /// </summary>
    /// <param name="ukaz">Glasovni ukaz.</param>
    public void IzvrsiUkaz(string ukaz)
    {
        if (PrepoznaUkaz(ukaz))
        {
            Console.WriteLine($"Izvajanje ukaza: '{ukaz}'.");
            // Simulacija izvajanja ukaza
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
                case "nastavi temperaturo":
                    Console.WriteLine("Temperatura je nastavljena.");
                    break;
                default:
                    Console.WriteLine("Izbran ukaz ni bil pravilno obdelan.");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"Ukaza '{ukaz}' ni mogoče izvesti, ker ni prepoznan.");
        }
    }
}
