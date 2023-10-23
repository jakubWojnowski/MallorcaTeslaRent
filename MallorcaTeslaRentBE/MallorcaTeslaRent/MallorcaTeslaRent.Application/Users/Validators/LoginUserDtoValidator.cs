using FluentValidation;
using MallorcaTeslaRent.Application.Users.Dto;

namespace MallorcaTeslaRent.Application.Users.Validators;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .NotEmpty();
    }
}