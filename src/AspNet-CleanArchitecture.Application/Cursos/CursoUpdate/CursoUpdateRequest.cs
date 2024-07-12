namespace AspNet_CleanArchitecture.Application.Cursos.CursoUpdate;

public class CursoUpdateRequest{
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? FechaPublicacion {get;set;}

}