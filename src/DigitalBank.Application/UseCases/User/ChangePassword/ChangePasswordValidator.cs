using DigitalBank.Communication.Requests;
using DigitalBank.Exceptions;
using FluentValidation;

namespace DigitalBank.Application.UseCases.User.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(u => u.NewPassword).NotEmpty().WithMessage(ResourceErrorMessages.SENHA_USUARIO_VAZIO);
        RuleFor(u => u.NewPassword.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceErrorMessages.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
    }
}
