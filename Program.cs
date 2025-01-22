using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj storitve za aplikacijo
builder.Services.AddControllers();

// Dodaj podporo za Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pametna Vrata API", Version = "v1" });
});

// Konfiguriraj povezavo do podatkovne baze
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Zgradi aplikacijo
var app = builder.Build();

// Nastavitve za razvojno okolje
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pametna Vrata API v1"));
}

// Omogoči zahtevke do API-ja
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Zaženi aplikacijo
app.Run();
