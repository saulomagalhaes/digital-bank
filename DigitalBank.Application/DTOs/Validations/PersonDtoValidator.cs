using DigitalBank.Application.DTOs.Person;
using FluentValidation;

namespace DigitalBank.Application.DTOs.Validations;

public class CreatePersonDtoValidator : AbstractValidator<CreatePersonDto>
{
    public CreatePersonDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}

public class UpdatePersonDtoValidator : AbstractValidator<UpdatePersonDto>
{
    public UpdatePersonDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}