using AspNet_CleanArchitecture.Application.Core;

namespace AspNet_CleanArchitecture.Application.Calificaciones.GetCalificaciones;

public class GetCalificacionesRequest : PagingParams
{

    public string? Alumno {get;set;}
    public Guid? CursoId {get;set;}

}