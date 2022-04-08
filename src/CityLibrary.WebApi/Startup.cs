using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using CityLibrary.Domain;
using CityLibrary.DataAccess;
using CityLibrary.DataAccess.Models;

namespace CityLibrary.WebApi;

public class Startup
{
    private const string _apiTitle = "CityLibrary.API";
    private const string _apiVersion = "v2";

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services
            .AddDomain()
            .AddDataAccess(
                Configuration.GetConnectionString("CityLibraryDb"),
                Configuration.GetSection("DatabaseCreationSettings").Get<DatabaseCreationSettings>())
            .AddWebApi();

        services.AddSwaggerGen(c => c.SwaggerDoc(_apiVersion, new OpenApiInfo { Title = _apiTitle, Version = _apiVersion }));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{_apiVersion}/swagger.json", $"{_apiTitle} {_apiVersion}"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}