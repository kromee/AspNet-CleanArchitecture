
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Infrastructure.Security;
using AspNet_CleanArchitecture.Persistence;
using AspNet_CleanArchitecture.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.WebApi.Extensions;


public static class IdentityServiceExtensions{
     public static IServiceCollection AddIdentityServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {

    services.AddIdentityCore<AppUser>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
    }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();


        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserAccessor, UserAccessor>();

        return services;
    }

}