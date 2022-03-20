using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Repositories;
using DataAccess.Repositories;

namespace DataAccess;

public static class DataAccessRegistrator
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IGenreRepository, GenreRepository>()
            .AddScoped<IPersonRepository, PersonRepository>();

        services
            .AddAutoMapper(typeof(DataAccess.MapperProfile))
            .AddDbContext<CityLibraryDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}