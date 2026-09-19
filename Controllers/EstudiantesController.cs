using Microsoft.AspNetCore.Mvc;
using ProgramacionV.Api.Models;
using ProgramacionV.Api.Repositories;

namespace ProgramacionV.Api.Controllers;

[ApiController]
[Route("api/estudiantes")]
public class EstudiantesController : ControllerBase
{
    private readonly EstudianteRepository _repository;

    public EstudiantesController(
        EstudianteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var estudiantes =
            await _repository.GetAllAsync();
        return Ok(estudiantes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var estudiante =
            await _repository.GetByIdAsync(id);

        if (estudiante is null)
            return NotFound();

        return Ok(estudiante);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Estudiante estudiante)
    {
        estudiante.ProgramaAcademico = null;
        var creado =
            await _repository.CreateAsync(estudiante);
        return Ok(creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        Estudiante estudiante)
    {
        estudiante.Id = id;
        var actualizado =
            await _repository.UpdateAsync(estudiante);

        if (!actualizado)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var eliminado =
            await _repository.DeleteAsync(id);

        if (!eliminado)
            return NotFound();

        return NoContent();
    }
}
