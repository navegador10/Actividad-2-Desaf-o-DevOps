using Microsoft.EntityFrameworkCore;
using ProgramacionV.Api.Data;
using ProgramacionV.Api.Models;

namespace ProgramacionV.Api.Repositories;

public class ProgramaRepository
{
    private readonly AppDbContext _context;

    public ProgramaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProgramaAcademico>> GetAllAsync()
    {
        return await _context.ProgramasAcademicos
            .ToListAsync();
    }

    public async Task<ProgramaAcademico?> GetByIdAsync(int id)
    {
        return await _context.ProgramasAcademicos
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ProgramaAcademico> CreateAsync(
        ProgramaAcademico programa)
    {
        _context.ProgramasAcademicos.Add(programa);
        await _context.SaveChangesAsync();
        return programa;
    }

    public async Task<bool> UpdateAsync(
        ProgramaAcademico programa)
    {
        var actual = await _context.ProgramasAcademicos
            .FindAsync(programa.Id);

        if (actual is null)
            return false;

        actual.Codigo = programa.Codigo;
        actual.Nombre = programa.Nombre;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var programa = await _context.ProgramasAcademicos
            .FindAsync(id);

        if (programa is null)
            return false;

        _context.ProgramasAcademicos.Remove(programa);
        await _context.SaveChangesAsync();
        return true;
    }
}
