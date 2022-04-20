using Microsoft.Extensions.DependencyInjection;
using CityLibrary.Domain.Interfaces.Services;
using CityLibrary.Domain.Services;

namespace CityLibrary.Domain.Configuration;

public static class DomainRegistrator
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddScoped<IAuthorService, AuthorService>()
            .AddScoped<IBookService, BookService>()
            .AddScoped<IGenreService, GenreService>()
            .AddScoped<IPersonService, PersonService>();

        return services;
    }
}