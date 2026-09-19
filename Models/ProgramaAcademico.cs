namespace ProgramacionV.Api.Models;

public class ProgramaAcademico
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public List<Estudiante> Estudiantes { get; set; } = [];
}
