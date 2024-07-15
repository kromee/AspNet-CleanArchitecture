using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Domain;
using AspNet_CleanArchitecture.Persistence;
using AspNet_CleanArchitecture.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AspNet_CleanArchitecture.Infrastructure.Security;



public class TokenService : ITokenService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public TokenService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> CreateToken(AppUser user)
    {
        var policies = await _context.Database.SqlQuery<string>($@"
                SELECT
                    aspr.ClaimValue
                FROM AspNetUsers a
                    LEFT JOIN AspNetUserRoles ar
                        ON a.Id=ar.UserId
                    LEFT JOIN AspNetRoleClaims aspr
                        ON ar.RoleId = aspr.RoleId
                    WHERE a.Id = {user.Id}
        ").ToListAsync();
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email!)
        };

        foreach(var policy in policies)
        {
            if(policy is not null)
            {
                claims.Add(new (CumstomClaims.POLICIES, policy));
            }
        }

        var creds = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]!)),
            SecurityAlgorithms.HmacSha256
        );

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}