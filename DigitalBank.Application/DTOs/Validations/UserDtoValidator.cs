using DigitalBank.Application.DTOs.User;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class UserDtoValidator : AbstractValidator<UserDto>
{
	public UserDtoValidator()
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
