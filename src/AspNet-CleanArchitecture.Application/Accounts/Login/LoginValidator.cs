using FluentValidation;

namespace AspNet_CleanArchitecture.Application.Accounts;


public class LoginValidator : AbstractValidator<LoginRequest>{
public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}