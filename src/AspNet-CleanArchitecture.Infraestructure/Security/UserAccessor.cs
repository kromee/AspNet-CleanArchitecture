using System.Security.Claims;
using AspNet_CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace AspNet_CleanArchitecture.Infrastructure.Security;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUsername()
    {
       return _httpContextAccessor
        .HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
    }
}