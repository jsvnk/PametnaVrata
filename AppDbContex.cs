using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Pametne_naprave> Naprave { get; set; }
    public DbSet<Uporabnik> Uporabniki { get; set; }
    public DbSet<Administrator> Administratorji { get; set; }
    public DbSet<Glasovni_Asistent> GlasovniAsistenti { get; set; }
    public DbSet<Podatkovna_Analitika> PodatkovneAnalize { get; set; }
    public DbSet<Podatek> Podatki { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
             "Server=127.0.0.1;Port=3306;Database=pametna_vrata;User=root;Password=;",
             new MySqlServerVersion(new Version(8, 0, 33))
            );

        }
    }

}
