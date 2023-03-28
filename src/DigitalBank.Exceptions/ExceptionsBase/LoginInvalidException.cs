namespace DigitalBank.Exceptions.ExceptionsBase;

public class LoginInvalidException : DigitalBankExceptions
{
    public LoginInvalidException(): base(ResourceErrorMessages.LOGIN_INVALIDO)
    {
        
    }
}
