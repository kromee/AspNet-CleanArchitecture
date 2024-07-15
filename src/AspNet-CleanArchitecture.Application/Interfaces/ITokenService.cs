using AspNet_CleanArchitecture.Persistence.Models;

namespace AspNet_CleanArchitecture.Application.Interfaces;


public interface ITokenService{
    Task<string> CreateToken (AppUser user);
}