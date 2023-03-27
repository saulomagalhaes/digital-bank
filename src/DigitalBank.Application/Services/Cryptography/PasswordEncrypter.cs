using System.Security.Cryptography;
using System.Text;

namespace DigitalBank.Application.Services.Cryptography;

public class PasswordEncrypter
{
    public string Encrypt(string password)
    {
        var bytes = Encoding.UTF8.GetBytes(password);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }

    private string StringBytes(byte[] hashBytes)
    {
        var sb = new StringBuilder();
        foreach (var hashByte in hashBytes)
        {
            var hex = hashByte.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
