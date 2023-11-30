using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Infrastructure.Data;
using OmoqoCodeChallenge.Infrastructure.Repositories;

namespace OmoqoCodeChallenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<OmoqoCodeChallengeDBContext>(opt => opt.UseInMemoryDatabase("OmoqoCodeChallenge"));
        services.AddScoped<IShipRepository, ShipRepository>();
        return services;
    }
}