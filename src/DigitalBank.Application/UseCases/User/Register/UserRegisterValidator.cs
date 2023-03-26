using DigitalBank.Communication.Requests;
using DigitalBank.Exceptions;
using FluentValidation;

namespace DigitalBank.Application.UseCases.User.Register;

public class UserRegisterValidator : AbstractValidator<RequestRegisterUserJson>
{
    public UserRegisterValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage(ResourceErrorMessages.NOME_USUARIO_VAZIO);
        
        RuleFor(u => u.Email).NotEmpty().WithMessage(ResourceErrorMessages.EMAIL_USUARIO_VAZIO);
        When(u => !string.IsNullOrWhiteSpace(u.Email), () =>
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage(ResourceErrorMessages.EMAIL_USUARIO_INVALIDO);
        });

        RuleFor(u => u.Password).NotEmpty().WithMessage(ResourceErrorMessages.SENHA_USUARIO_VAZIO);
        RuleFor(u => u.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceErrorMessages.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);

    }
}
