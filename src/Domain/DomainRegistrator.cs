using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Services;
using Domain.Services;

namespace Domain;

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