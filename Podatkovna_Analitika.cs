using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Podatkovna_Analitika
{
    [Key]
    public int Id { get; set; }

    // Zgodovina porabe energije
    public List<double> ZgodovinaPorabe { get; set; } = new List<double>();

    // Nadomestek za Dictionary<string, double>
    public List<Podatek> TrenutniPodatki { get; set; } = new List<Podatek>();

    /// <summary>
    /// Izračuna analizo porabe energije za določeno obdobje.
    /// </summary>
    /// <param name="obdobje">Obdobje za analizo (npr. "tedensko", "mesečno").</param>
    /// <returns>Rezultati analize kot niz.</returns>
    public string IzracunajAnalizo(string obdobje)
    {
        if (ZgodovinaPorabe == null || ZgodovinaPorabe.Count == 0)
        {
            return "Ni podatkov za analizo.";
        }

        double povprecnaPoraba = ZgodovinaPorabe.Average();
        double najvecjaPoraba = ZgodovinaPorabe.Max();
        double najmanjsaPoraba = ZgodovinaPorabe.Min();

        return $"Analiza porabe za obdobje '{obdobje}':\n" +
               $"- Povprečna poraba: {povprecnaPoraba:F2} kWh\n" +
               $"- Največja poraba: {najvecjaPoraba:F2} kWh\n" +
               $"- Najmanjša poraba: {najmanjsaPoraba:F2} kWh";
    }

    /// <summary>
    /// Pridobi priporočila za varčevanje z energijo na podlagi trenutnih podatkov.
    /// </summary>
    /// <returns>Seznam priporočil kot nizov.</returns>
    public List<string> PridobiPriporocila()
    {
        var priporocila = new List<string>();

        foreach (var podatek in TrenutniPodatki)
        {
            if (podatek.Vrednost > 1.0) // Če naprava porablja več kot 1 kWh
            {
                priporocila.Add($"Naprava '{podatek.Ključ}' porablja veliko energije ({podatek.Vrednost:F2} kWh). Razmislite o izklopu.");
            }
            else
            {
                priporocila.Add($"Naprava '{podatek.Ključ}' ima optimalno porabo energije.");
            }
        }

        if (priporocila.Count == 0)
        {
            priporocila.Add("Ni podatkov za podajo priporočil.");
        }

        return priporocila;
    }
}
