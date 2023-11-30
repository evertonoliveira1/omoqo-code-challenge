using Microsoft.EntityFrameworkCore;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Application.UseCases;
using OmoqoCodeChallenge.Domain.Entities;
using OmoqoCodeChallenge.Infrastructure.Data;
using OmoqoCodeChallenge.Infrastructure.Repositories;

namespace OmoqoCodeChallenge.Test
{
    public class ShipServiceUnitTest
    {
        private readonly IShipService _shipService;

        public ShipServiceUnitTest()
        {
            DbContextOptions<OmoqoCodeChallengeDBContext> contextOptions = new DbContextOptionsBuilder<OmoqoCodeChallengeDBContext>()
                .UseInMemoryDatabase("OmoqoCodeChallenge")
                .Options;

            OmoqoCodeChallengeDBContext context = new OmoqoCodeChallengeDBContext(contextOptions);

            IShipRepository shipRepository = new ShipRepository(context);
            _shipService = new ShipService(shipRepository);

            using OmoqoCodeChallengeDBContext scopedContext = new OmoqoCodeChallengeDBContext(contextOptions);

            scopedContext.Database.EnsureDeleted();
            scopedContext.Database.EnsureCreated();

            scopedContext.Ships.Add(new Ship
            {
                Name = "Ship 001",
                Code = "AAAA-1111-A1",
                Length = 10,
                Width = 20
            }
            );

            scopedContext.SaveChanges();
        }

        [Fact(DisplayName = "Should return an error when model is missing fields")]
        async void Create_Invalid_ShouldReturnShipEntity()
        {
            try
            {
                Ship ship = new Ship
                {
                    Name = "Ship 002",
                    Length = 20,
                    Width = 30
                };

                Ship shipResponse = await _shipService.Create(ship);
            } catch (Exception ex)
            {
                Assert.Equal("Failed validations: Code is required, Invalid Code. You must use the pattern: 'AAAA-1111-A1'", ex.Message);
            }
        }

        [Fact(DisplayName = "Should return a successful ship response")]
        async void Create_Valid_ShouldReturnShipEntity()
        {
            Ship ship = new Ship
            {
                Name = "Ship 002",
                Code = "AAAA-1111-A1",
                Length = 20,
                Width = 30
            };

            Ship shipResponse = await _shipService.Create(ship);

            Assert.Equal("Ship 002", shipResponse.Name);
            Assert.Equal("AAAA-1111-A1", shipResponse.Code);
            Assert.Equal(20, shipResponse.Length);
            Assert.Equal(30, shipResponse.Width);

        }
    }
}
