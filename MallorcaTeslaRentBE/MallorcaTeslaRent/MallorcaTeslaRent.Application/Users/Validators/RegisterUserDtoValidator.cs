using FluentValidation;
using MallorcaTeslaRent.Application.Users.Dto;
using MallorcaTeslaRent.Application.Users.Validators.Helpers;
using MallorcaTeslaRent.Domain.Entities;
using MallorcaTeslaRent.Domain.Interfaces;

namespace MallorcaTeslaRent.Application.Users.Validators;

internal sealed class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator(IGenericRepository<User,Guid> userRepository)
    {
        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .Custom((value, context) =>
            {
                var user = userRepository.AnyAsync(u => u.Email == value);
                if (user.Result) context.AddFailure("Email", "Email already exists");
            });
        RuleFor(r => r.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Must(PasswordHelper.HasNumber).WithMessage("Password must contain at least one number")
            .Must(PasswordHelper.HasCapitals).WithMessage("Password must contain at least one capital letter")
            .Must(PasswordHelper.HasLowercase).WithMessage("Password must contain at least one lowercase letter")
            .Must(PasswordHelper.HasSpecialCharacters).WithMessage("Password must contain at least one special character");
        RuleFor(r => r.ConfirmPassword)
            .NotEmpty()
            .Equal(r => r.Password)
            .WithMessage("Passwords do not match");
        RuleFor(r => r.Role)
            .NotEmpty()
            .IsInEnum();
    }
    
}