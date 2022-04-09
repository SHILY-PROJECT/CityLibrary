using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CityLibrary.Domain.Interfaces.Repositories;
using CityLibrary.DataAccess.Models;
using CityLibrary.DataAccess.Repositories;

namespace CityLibrary.DataAccess;

public static class DataAccessRegistrator
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString, DatabaseCreationSettings databaseCreationSettings)
    {
        services
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IPersonRepository, PersonRepository>();

        services.AddScoped(x => databaseCreationSettings);

        services
            .AddAutoMapper(typeof(DataAccess.MapperProfile))
            .AddDbContext<CityLibraryDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}