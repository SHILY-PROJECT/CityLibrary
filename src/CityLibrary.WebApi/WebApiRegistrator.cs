using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using CityLibrary.WebApi.Models.Persons.Validators;
using FluentValidation.AspNetCore;

namespace CityLibrary.WebApi;

public static class WebApiRegistrator
{
    public static IServiceCollection AddWebApi(this IServiceCollection services)
    {
        services
            .AddAutoMapper(typeof(MapperProfile))
            .AddValidatorsFromAssemblyContaining<Startup>(ServiceLifetime.Transient);

        return services;
    }
}