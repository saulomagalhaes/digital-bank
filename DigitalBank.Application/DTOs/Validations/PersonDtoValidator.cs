using DigitalBank.Application.DTOs.Person;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class CreatePersonDtoValidator : AbstractValidator<CreatePersonDto>
{
	public CreatePersonDtoValidator()
	{
		RuleFor(p => p.Name)
			.NotEmpty()
			.NotNull()
			.WithMessage("O Name deve ser informado");

        RuleFor(p => p.Name)
			.NotEmpty()
			.NotNull()
			.WithMessage("O Name deve ser informado");
    }
}

public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
{
    public UpdatePersonDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("O Name deve ser informado");

        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("O Name deve ser informado");
    }
}
