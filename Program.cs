using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Dodajte Swagger generator
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Omogočite Swagger UI za vsa okolja
app.UseSwagger();
app.UseSwaggerUI();

// Nastavite aplikacijo, da posluša na vseh naslovih (potrebno za Docker)
app.Urls.Add("http://0.0.0.0:80");

// Mapirajte kontrolerje
app.MapControllers();

app.Run();
