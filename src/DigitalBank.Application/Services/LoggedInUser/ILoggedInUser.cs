using DigitalBank.Domain.Entities;

namespace DigitalBank.Application.Services.LoggedInUser;

public interface ILoggedInUser
{
    Task<User> RecoverUser();
}