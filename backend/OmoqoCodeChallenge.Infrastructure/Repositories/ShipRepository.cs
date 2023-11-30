using Microsoft.EntityFrameworkCore;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Domain.Entities;
using OmoqoCodeChallenge.Infrastructure.Data;

namespace OmoqoCodeChallenge.Infrastructure.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly OmoqoCodeChallengeDBContext _dbContext;
        public ShipRepository(OmoqoCodeChallengeDBContext context)
        {
            _dbContext = context;
        }

        async Task<Ship?> IShipRepository.GetById(int id)
        {
            Ship? ship = await _dbContext.Ships.FindAsync(id);
            return ship;
        }

        async Task<Ship> IShipRepository.Create(Ship ship)
        {
            await _dbContext.Ships.AddAsync(ship);
            await _dbContext.SaveChangesAsync();

            return ship;
        }
        async Task<Ship> IShipRepository.Update(Ship ship)
        {
            _dbContext.Ships.Update(ship);
            await _dbContext.SaveChangesAsync();
            return ship;
        }

        async Task<bool> IShipRepository.Delete(Ship ship)
        {
            _dbContext.Ships.Remove(ship);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        async Task<List<Ship>> IShipRepository.GetAll(ShipFilter filter)
        {
            try
            {
                IQueryable<Ship> query = _dbContext.Ships;

                if (!string.IsNullOrEmpty(filter.Code))
                    query = query.Where(x => x.Code.ToLower().Contains(filter.Code.ToLower()));

                if (filter.Page != null && filter.Limit != null)
                {
                    int skip = filter.Page.Value * filter.Limit.Value;

                    query = query
                    .Skip(skip)
                    .Take(filter.Limit.Value);
                }
                else if (filter.Limit != null && filter.Page == null)
                {
                    query = query
                    .Take((int)filter.Limit);
                }

                return await query.ToListAsync();
            }
            catch (Exception)
            {
                return new List<Ship>();
            }
        }

        async Task<int> IShipRepository.CountAsync(ShipFilter filter)
        {
            try
            {
                IQueryable<Ship> query = _dbContext.Ships;

                if (!string.IsNullOrEmpty(filter.Code))
                    query = query.Where(x => x.Code == filter.Code);

                return await query.CountAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
