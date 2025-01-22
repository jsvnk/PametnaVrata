using System.ComponentModel.DataAnnotations;

public class Podatek
{
    [Key]
    public int Id { get; set; }
    public string Ključ { get; set; } = string.Empty; // Inicializacija
    public double Vrednost { get; set; }
}
