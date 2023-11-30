using OmoqoCodeChallenge.Infrastructure.Data;

namespace OmoqoCodeChallenge.Api.Extensions;

public static class DbInitializerExtension
{
    public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));

        using IServiceScope scope = app.ApplicationServices.CreateScope();

        OmoqoCodeChallengeDBContext context = scope.ServiceProvider.GetRequiredService<OmoqoCodeChallengeDBContext>();
        DbInitializer.Initialize(context);
        return app;
    }
}