using Microsoft.EntityFrameworkCore;
using ProgramacionV.Api.Data;
using ProgramacionV.Api.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Habilita los controladores.
builder.Services.AddControllers();

// Habilita OpenAPI.
builder.Services.AddOpenApi();

// Configura SQLite.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"));
});

// Registra los repositorios.
builder.Services.AddScoped<ProgramaRepository>();
builder.Services.AddScoped<EstudianteRepository>();

var app = builder.Build();

// Publica el documento OpenAPI.
app.MapOpenApi();

// Habilita Scalar.
app.MapScalarApiReference(options =>
{
    options.WithTitle(
        "Programación V - API Gestión Académica");
});

// Cuando se ingresa a la raíz,
// redirige automáticamente hacia Scalar.
app.MapGet("/", () =>
    Results.Redirect("/scalar/v1"));

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
