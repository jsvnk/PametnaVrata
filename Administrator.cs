using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Administrator
{
    [Key]
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Email { get; set; }

    // Relacija z napravami
    public List<Pametne_naprave> Naprave { get; set; } = new List<Pametne_naprave>();

    /// <summary>
    /// Dodaj novo napravo na seznam upravljanih naprav.
    /// </summary>
    /// <param name="naprava">Naprava, ki jo želi administrator dodati.</param>
    public void DodajNapravo(Pametne_naprave naprava)
    {
        if (naprava == null)
        {
            throw new ArgumentNullException(nameof(naprava), "Naprava ne sme biti null.");
        }

        if (!Naprave.Contains(naprava))
        {
            Naprave.Add(naprava);
            Console.WriteLine($"Naprava {naprava.Tip} je bila uspešno dodana.");
        }
        else
        {
            Console.WriteLine($"Naprava {naprava.Tip} že obstaja na seznamu.");
        }
    }

    /// <summary>
    /// Odstrani obstoječo napravo s seznama upravljanih naprav.
    /// </summary>
    /// <param name="naprava">Naprava, ki jo želi administrator odstraniti.</param>
    public void OdstraniNapravo(Pametne_naprave naprava)
    {
        if (naprava == null)
        {
            throw new ArgumentNullException(nameof(naprava), "Naprava ne sme biti null.");
        }

        if (Naprave.Contains(naprava))
        {
            Naprave.Remove(naprava);
            Console.WriteLine($"Naprava {naprava.Tip} je bila uspešno odstranjena.");
        }
        else
        {
            Console.WriteLine($"Naprava {naprava.Tip} ne obstaja na seznamu.");
        }
    }
}
