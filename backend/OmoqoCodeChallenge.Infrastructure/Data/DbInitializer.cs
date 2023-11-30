using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(OmoqoCodeChallengeDBContext context)
    {
        context.Database.EnsureCreated();

        if (context.Ships.Any())
            return;

        for (int i = 0; i < 50; i++)
        {
            var random = new Random();

            context.Ships.Add(new Ship
            {
                Name = "Ship " + (i+1),
                Length = (decimal)random.NextDouble() * 10,
                Width = (decimal)random.NextDouble() * 10,
                Code = DataFaker.GenerateFakeCode()
            });
        }

        context.SaveChanges();
    }
}