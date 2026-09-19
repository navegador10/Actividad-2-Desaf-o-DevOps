using Microsoft.EntityFrameworkCore;
using ProgramacionV.Api.Data;
using ProgramacionV.Api.Models;

namespace ProgramacionV.Api.Repositories;

public class EstudianteRepository
{
    private readonly AppDbContext _context;

    public EstudianteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Estudiante>> GetAllAsync()
    {
        return await _context.Estudiantes
            .Include(x => x.ProgramaAcademico)
            .ToListAsync();
    }

    public async Task<Estudiante?> GetByIdAsync(int id)
    {
        return await _context.Estudiantes
            .Include(x => x.ProgramaAcademico)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Estudiante> CreateAsync(
        Estudiante estudiante)
    {
        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync();
        return estudiante;
    }

    public async Task<bool> UpdateAsync(
        Estudiante estudiante)
    {
        var actual = await _context.Estudiantes
            .FindAsync(estudiante.Id);

        if (actual is null)
            return false;

        actual.Documento = estudiante.Documento;
        actual.Nombre = estudiante.Nombre;
        actual.Correo = estudiante.Correo;
        actual.Telefono = estudiante.Telefono;
        actual.ProgramaAcademicoId =
            estudiante.ProgramaAcademicoId;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var estudiante = await _context.Estudiantes
            .FindAsync(id);

        if (estudiante is null)
            return false;

        _context.Estudiantes.Remove(estudiante);
        await _context.SaveChangesAsync();
        return true;
    }
}
