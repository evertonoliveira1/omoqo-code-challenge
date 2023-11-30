using System.Reflection;
using OmoqoCodeChallenge.Application;
using OmoqoCodeChallenge.Infrastructure;

namespace OmoqoCodeChallenge.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            });
        });

        services.AddInfrastructureServices();
        services.AddApplicationServices();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}