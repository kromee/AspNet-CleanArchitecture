
using System.Security.Cryptography.X509Certificates;

namespace AspNet_CleanArchitecture.Application.Photos.GetPhoto;
public record PhotoResponse(
    Guid? Id,
    string? Url,
    Guid? CursoId
)
{
    public PhotoResponse(): this(null, null, null)
    {
    }
}
