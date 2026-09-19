using Microsoft.EntityFrameworkCore;
using ProgramacionV.Api.Models;

namespace ProgramacionV.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProgramaAcademico> ProgramasAcademicos { get; set; }
    public DbSet<Estudiante> Estudiantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ---------------------------------------------------------
        // DATOS SEMILLA - PROGRAMAS ACADÉMICOS
        // ---------------------------------------------------------
        modelBuilder.Entity<ProgramaAcademico>().HasData(
            new ProgramaAcademico
            {
                Id = 1,
                Codigo = "SIS",
                Nombre = "Ingeniería de Sistemas"
            },
            new ProgramaAcademico
            {
                Id = 2,
                Codigo = "ADM",
                Nombre = "Administración de Empresas"
            }
        );

        // ---------------------------------------------------------
        // DATOS SEMILLA - ESTUDIANTES
        // ---------------------------------------------------------
        modelBuilder.Entity<Estudiante>().HasData(
            new Estudiante
            {
                Id = 1,
                Documento = "1001001001",
                Nombre = "Ana Torres",
                Correo = "ana.torres@universidad.edu.co",
                Telefono = "3001111111",
                ProgramaAcademicoId = 1
            },
            new Estudiante
            {
                Id = 2,
                Documento = "1001001002",
                Nombre = "Carlos Gómez",
                Correo = "carlos.gomez@universidad.edu.co",
                Telefono = "3002222222",
                ProgramaAcademicoId = 1
            },
            new Estudiante
            {
                Id = 3,
                Documento = "1001001003",
                Nombre = "Laura Pérez",
                Correo = "laura.perez@universidad.edu.co",
                Telefono = "3003333333",
                ProgramaAcademicoId = 1
            },
            new Estudiante
            {
                Id = 4,
                Documento = "1001001004",
                Nombre = "Miguel Ramírez",
                Correo = "miguel.ramirez@universidad.edu.co",
                Telefono = "3004444444",
                ProgramaAcademicoId = 2
            },
            new Estudiante
            {
                Id = 5,
                Documento = "1001001005",
                Nombre = "Sofía Martínez",
                Correo = "sofia.martinez@universidad.edu.co",
                Telefono = "3005555555",
                ProgramaAcademicoId = 2
            }
        );
    }
}
