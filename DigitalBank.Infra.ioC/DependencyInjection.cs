using DigitalBank.Application.Contracts.Services;
using DigitalBank.Application.Profiles;
using DigitalBank.Application.Services;
using DigitalBank.Domain.Contracts.Repositories;
using DigitalBank.Infra.Data.Context;
using DigitalBank.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalBank.Infra.ioC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DigitalBankConnection");
        
        services.AddEntityFrameworkSqlServer()
        .AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }

    public static IServiceCollection AddServices (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(PersonProfile));
        services.AddScoped<IPersonService, PersonService>();

        return services;
    }
}
