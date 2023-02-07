using DigitalBank.Application.DTOs.User;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
	public LoginUserDtoValidator()
	{
        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull();
    }
}

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    public RegisterUserDtoValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(p => p.Password)
            .NotEmpty()
            .NotNull();

        RuleFor(p => p.ConfirmPassword)
            .NotEmpty()
            .NotNull();
    }
}
