namespace DigitalBank.Exceptions.ExceptionsBase;

public class DigitalBankExceptions : SystemException
{
    public DigitalBankExceptions()
    {
        
    }
    public DigitalBankExceptions(string message) : base(message)
    {
    }
}
