using DigitalBank.Domain.Entities;

namespace DigitalBank.Domain.Contracts.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(User user);
}
