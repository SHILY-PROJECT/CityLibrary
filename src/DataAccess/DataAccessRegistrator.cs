using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessRegistrator
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {

        return services;
    }
}