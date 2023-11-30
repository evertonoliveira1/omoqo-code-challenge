using Microsoft.Extensions.DependencyInjection;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Application.UseCases;

namespace OmoqoCodeChallenge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IShipService, ShipService>();
        return services;
    }
}