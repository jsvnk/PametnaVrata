using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Konstruktor za sprejem konfiguracije iz Program.cs
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Tabele v bazi podatkov
    public DbSet<Pametne_naprave> Naprave { get; set; }
    public DbSet<Uporabnik> Uporabniki { get; set; }
    public DbSet<Administrator> Administratorji { get; set; }
    public DbSet<Glasovni_Asistent> GlasovniAsistenti { get; set; }
    public DbSet<Podatkovna_Analitika> PodatkovneAnalize { get; set; }
    public DbSet<Podatek> Podatki { get; set; }

    // Konfiguracija baze podatkov
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=pametna_vrata.db");
        }
    }
}
