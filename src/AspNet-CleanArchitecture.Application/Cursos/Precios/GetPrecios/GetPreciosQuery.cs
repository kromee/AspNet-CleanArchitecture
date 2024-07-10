using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AspNet_CleanArchitecture.Application.Precios.GetPrecios;

public record PrecioResponse(
    Guid? Id,
    string? Nombre,
    decimal? PrecioActual,
    decimal? PrecioPromocion
)
{
    public PrecioResponse(): this(null, null, null, null)
    {
    }
}