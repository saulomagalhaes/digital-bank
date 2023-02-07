namespace DigitalBank.Application.Utils;

public static class GenerateAccountNumber
{
    public static string GenerateRandomNumber()
    {
        Random random = new Random();
        int firstPart = random.Next(10000, 99999);
        int secondPart = random.Next(1, 9);
        return firstPart + "-" + secondPart;
    }
}
