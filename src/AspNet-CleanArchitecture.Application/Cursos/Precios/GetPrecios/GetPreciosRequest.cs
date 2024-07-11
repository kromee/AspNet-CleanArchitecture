using AspNet_CleanArchitecture.Application.Core;

namespace AspNet_CleanArchitecture.Application.Precios.GetPrecios;

public class GetPreciosRequest : PagingParams
{
    public string? Nombre {get;set;}

}