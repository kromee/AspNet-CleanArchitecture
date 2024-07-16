
using System.Text;
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Infrastructure.Security;
using AspNet_CleanArchitecture.Persistence;
using AspNet_CleanArchitecture.Persistence.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

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

        var key = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(configuration["TokenKey"]!));


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer( opt=>{
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



        return services;
    }

}