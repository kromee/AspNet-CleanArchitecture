using FluentValidation;
using Bogus;

namespace AspNet_CleanArchitecture.Application.Accounts.Register;

public class RegisterValidator: AbstractValidator<RegisterRequest>{
public RegisterValidator(){
    RuleFor(x => x.Email).NotEmpty().EmailAddress().NotEmpty().WithMessage("Indique un Email");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Indique un Password");
            RuleFor(x => x.NombreCompleto).NotEmpty().WithMessage("Indique un nombre con apellidos");
            RuleFor(x => x.Carrera).NotEmpty().WithMessage("Indique su carrera profesional");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Indique un nombre de usuario");
    }
}