using Microsoft.EntityFrameworkCore;
using YCDemoMVC.DBModel;

namespace YCDemoMVC.Extentions;

public static class DbConnectionExtension
{
    public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DBConnectionString");
        services.AddDbContext<YCDemoContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptionsAction:
                sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                });
        });

        return services;
    }
}