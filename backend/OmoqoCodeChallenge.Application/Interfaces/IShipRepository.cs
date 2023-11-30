using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Application.Interfaces
{
    public interface IShipRepository
    {
        Task<int> CountAsync(ShipFilter filter);
        Task<List<Ship>> GetAll(ShipFilter filter);

        Task<Ship?> GetById(int id);

        Task<Ship> Create(Ship ship);

        Task<Ship> Update(Ship ship);

        Task<bool> Delete(Ship ship);
    }
}