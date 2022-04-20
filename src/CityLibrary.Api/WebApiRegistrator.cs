using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using CityLibrary.Api.Models.Persons.Validators;
using FluentValidation.AspNetCore;

namespace CityLibrary.Api;

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