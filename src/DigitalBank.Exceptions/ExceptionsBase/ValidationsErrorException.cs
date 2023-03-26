namespace DigitalBank.Exceptions.ExceptionsBase;

public class ValidationsErrorException : DigitalBankExceptions
{
    public List<string> ErrorMessages { get; set; }

    public ValidationsErrorException(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
