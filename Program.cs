﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dodajte storitve v odvisnostni vbrizgovalnik
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodajte kontekst podatkovne baze
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracija aplikacije
var app = builder.Build();

// Omogočanje Swaggerja samo v razvojnem okolju
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "swagger";
        options.SwaggerEndpoint($"/swagger/v1/swagger.json", "My API");
        options.EnableDeepLinking();
    });
    app.UseStaticFiles();
}

// Omogočite preusmeritev na HTTPS
app.UseHttpsRedirection();

// Omogočite usmerjanje zahtevkov
app.UseRouting();

// Omogočite avtorizacijo
app.UseAuthorization();

// Preslikajte končne točke krmilnikov
app.MapControllers();

// Zaženite aplikacijo
app.Run();
