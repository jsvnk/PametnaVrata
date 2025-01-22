using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracija povezave na MySQL bazo
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        "Server=127.0.0.1;Port=3306;Database=pametna_vrata;User=root;Password=;",
        new MySqlServerVersion(new Version(11, 4, 4))
    )
);

// Dodajanje kontrolerjev in Swaggerja
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Gradnja aplikacije
var app = builder.Build();

// Omogočanje Swaggerja samo v razvojnem okolju
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiDemo v1");
        c.RoutePrefix = "swagger";
    });
}

    // Omogočanje HTTPS preusmeritev in statičnih datotek
    app.UseHttpsRedirection();
app.UseStaticFiles(); // Omogoča dostop do statičnih datotek

// Omogočanje usmerjanja in avtorizacije
app.UseRouting();
app.UseAuthorization();

// Preslikava kontrolerjev na končne točke
app.MapControllers();

// Zaženite aplikacijo
app.Run();
