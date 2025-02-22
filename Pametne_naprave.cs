﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Pametne_naprave
{
    [Key]
    public int Id { get; set; }
    public string Tip { get; set; } = string.Empty; // Inicializacija
    public bool Stanje { get; set; }
    public double PorabaEnergije { get; set; }

    // Hard-coded podatki za testiranje
    public static List<Pametne_naprave> GetTestData()
    {
        return new List<Pametne_naprave>
        {
            new Pametne_naprave { Tip = "Vrata", Stanje = true, PorabaEnergije = 0.12 },
            new Pametne_naprave { Tip = "Luč", Stanje = false, PorabaEnergije = 0.15 },
            new Pametne_naprave { Tip = "Termostat", Stanje = true, PorabaEnergije = 0.25 }
        };
    }
}
