using DigitalBank.Infra.Data.Context;
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

        return services;
    }
}
