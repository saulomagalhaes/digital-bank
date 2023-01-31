using DigitalBank.Application.DTOs.Account;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
{
	public CreateAccountDtoValidator()
	{
		RuleFor(a => a.Number)
			.NotEmpty()
			.NotNull();

		RuleFor(a => a.Balance) 
			.NotEmpty()
			.NotNull();

		RuleFor(a => a.PersonId)
			.NotEmpty()
			.NotNull();
	}
}

public class UpdateAccountDtoValidator : AbstractValidator<UpdateAccountDto>
{
    public UpdateAccountDtoValidator()
    {
        RuleFor(a => a.Number)
            .NotEmpty()
            .NotNull();

        RuleFor(a => a.Balance)
            .NotEmpty()
            .NotNull();
    }
}