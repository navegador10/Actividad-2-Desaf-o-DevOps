namespace ProgramacionV.Api.Models;

public class Estudiante
{
    public int Id { get; set; }
    public string Documento { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public int ProgramaAcademicoId { get; set; }
    public ProgramaAcademico? ProgramaAcademico { get; set; }
}
