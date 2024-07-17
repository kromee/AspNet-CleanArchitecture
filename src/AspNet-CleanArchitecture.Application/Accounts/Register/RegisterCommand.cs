using FluentValidation;
using AspNet_CleanArchitecture.Application.Core;
using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Persistence.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

 
 namespace AspNet_CleanArchitecture.Application.Accounts.Register;


public class RegisterCommand
{
public  record RegisterCommandRequest(RegisterRequest registerRequest):IRequest<Result<Profile>>;

internal class RegisterCommandHandler: IRequestHandler<RegisterCommandRequest, Result<Profile>>
{
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        public RegisterCommandHandler(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        public async Task<Result<Profile>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
           
            if(await  _userManager.Users
            .AnyAsync(x=> x.Email == request.registerRequest.Email))
            {
                Result<Profile>.Failure("El email ya fue registrado por otro usuario");
            }

            if(await _userManager.Users
            .AnyAsync(x=>x.UserName == request.registerRequest.Username))
            {
                Result<Profile>.Failure("El username ya fue registrado");
            }

             var user = new AppUser
             {
                NombreCompleto = request.registerRequest.NombreCompleto,
                Id = Guid.NewGuid().ToString(),
                Carrera = request.registerRequest.Carrera,
                Email = request.registerRequest.Email,
                UserName  = request.registerRequest.Username
             };
           
            var resultado =  await _userManager
            .CreateAsync(user, request.registerRequest.Password!);

            if(resultado.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Client");
                
                var profile = new Profile
                {
                    Email = user.Email,
                    NombreCompleto = user.NombreCompleto,
                    Token = await _tokenService.CreateToken(user),
                    Username = user.UserName
                };

                return Result<Profile>.Success(profile);
            }

            return Result<Profile>.Failure("Errores en el registro del usuario");
        }


}
  public class RegiterCommandRequestValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegiterCommandRequestValidator()
        {
            RuleFor(x => x.registerRequest).SetValidator(new RegisterValidator());
        }
    }

}