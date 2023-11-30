using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Application.Interfaces
{
    public interface IShipService
    {
        Task<long> CountAsync(ShipFilter filter);

        Task<List<Ship>> GetAll(ShipFilter filter);

        Task<Ship?> GetById(int id);

        Task<Ship> Create(Ship ship);

        Task<Ship> Update(Ship ship, int id);

        Task<bool> Delete(int id);
    }
}