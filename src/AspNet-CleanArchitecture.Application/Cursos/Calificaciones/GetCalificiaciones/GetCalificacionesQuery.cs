


namespace AspNet_CleanArchitecture.Application.Calificaciones.GetCalificaciones;
public record CalificacionResponse(
    string? Alumno,
    int? Puntaje,
    string? Comentario,
    string? NombreCurso
)
{
    public CalificacionResponse(): this(null, null, null, null)
    {
    }
}