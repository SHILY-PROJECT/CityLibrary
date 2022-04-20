using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using CityLibrary.DataAccess.Models;
using CityLibrary.DataAccess.Configuration;
using CityLibrary.Domain.Configuration;
using CityLibrary.Api.Configuration;

namespace CityLibrary.Api;

public class Startup
{
    private const string Title = "CityLibrary.API";
    private const string Version = "v2";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddFluentValidation();

        services
            .AddDomain()
            .AddDataAccess(
                Configuration.GetConnectionString("CityLibraryDb"),
                Configuration.GetSection("DatabaseCreationSettings").Get<DatabaseCreationSettings>())
            .AddWebApi();

        services.AddSwaggerGen(c => c.SwaggerDoc(Version, new OpenApiInfo { Title = Title, Version = Version }));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"{Title} {Version}"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}