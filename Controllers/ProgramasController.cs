using Microsoft.AspNetCore.Mvc;
using ProgramacionV.Api.Models;
using ProgramacionV.Api.Repositories;

namespace ProgramacionV.Api.Controllers;

[ApiController]
[Route("api/programas")]
public class ProgramasController : ControllerBase
{
    private readonly ProgramaRepository _repository;

    public ProgramasController(
        ProgramaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var programas =
            await _repository.GetAllAsync();
        return Ok(programas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var programa =
            await _repository.GetByIdAsync(id);

        if (programa is null)
            return NotFound();

        return Ok(programa);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        ProgramaAcademico programa)
    {
        var creado =
            await _repository.CreateAsync(programa);
        return Ok(creado);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        ProgramaAcademico programa)
    {
        programa.Id = id;
        var actualizado =
            await _repository.UpdateAsync(programa);

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
