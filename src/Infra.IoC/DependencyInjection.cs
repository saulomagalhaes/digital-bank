using DigitalBank.Application.Services.Cryptography;
using DigitalBank.Application.Services.Token;
using DigitalBank.Application.UseCases.User.Login;
using DigitalBank.Application.UseCases.User.Register;
using DigitalBank.Domain.Repositories;
using DigitalBank.Domain.Repositories.User;
using DigitalBank.Infra.Context;
using DigitalBank.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>()
            .AddScoped<IUserWriteOnlyRepository, UserRepository>()
            .AddScoped<IUserUpdateOnlyRepository, UserRepository>();
        
        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sectionLifeTimeToken = configuration.GetRequiredSection("Settings:LifeTimeToken");
        var sectionKeyToken = configuration.GetRequiredSection("Settings:KeyToken");

        services.AddScoped(option => new PasswordEncrypter())
            .AddScoped(option => new TokenController(int.Parse(sectionLifeTimeToken.Value), sectionKeyToken.Value));

        services.AddScoped<IUserRegisterUseCase, UserRegisterUseCase>()
            .AddScoped<ILoginUseCase, LoginUseCase>();
        return services;
    }
}
