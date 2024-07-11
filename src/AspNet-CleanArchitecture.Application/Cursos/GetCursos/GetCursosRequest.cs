namespace AspNet_CleanArchitecture.Application.Cursos.GetCursos;

using AspNet_CleanArchitecture.Application.Core;

public class GetCursosRequest: PagingParams{
     public string? Titulo {get;set;}
    public string? Descripcion {get;set;}
}
