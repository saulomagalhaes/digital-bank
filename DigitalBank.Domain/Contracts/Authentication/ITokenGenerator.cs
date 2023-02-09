using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Authentication;

public interface ITokenGenerator
{
    TokenData Generator(User user);
}
