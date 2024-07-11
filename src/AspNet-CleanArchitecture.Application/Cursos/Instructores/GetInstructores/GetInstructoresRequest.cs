using AspNet_CleanArchitecture.Application.Core;


namespace AspNet_CleanArchitecture.Application.Instructores.GetInstructores;
public class GetInstructoresRequest : PagingParams
{

    public string? Nombre {get;set;}
    public string? Apellido {get;set;}

}
