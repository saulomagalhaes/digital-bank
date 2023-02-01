using DigitalBank.Application.DTOs.Transaction;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class CreateTransactionDtoValidator : AbstractValidator<CreateTransactionDto>
{
	public CreateTransactionDtoValidator()
	{
		RuleFor(t => t.Amount)
			.NotEmpty()
			.NotNull();

        RuleFor(t => t.Description)
			.NotEmpty()
			.NotNull();

        RuleFor(t => t.AccountId)
			.NotEmpty()
			.NotNull();
    }
}

public class UpdateTransactionDtoValidator : AbstractValidator<UpdateTransactionDto>
{
    public UpdateTransactionDtoValidator()
    {
        RuleFor(t => t.Amount)
            .NotEmpty()
            .NotNull();

        RuleFor(t => t.Description)
            .NotEmpty()
            .NotNull();
    }
}
