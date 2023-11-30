using OmoqoCodeChallenge.Application.Exceptions;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Application.Validators;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Application.UseCases
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;

        public ShipService(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        async Task<Ship> IShipService.Create(Ship ship)
        {
            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            if (!validatorResult.IsValid)
                throw new UnprocessableEntityException(validatorResult.Message);

            await _shipRepository.Create(ship);
            return ship;
        }

        async Task<Ship> IShipService.Update(Ship ship, int id)
        {
            ValidatorResult validatorResult = ShipValidator.ValidateErrors(ship);

            if (!validatorResult.IsValid)
                throw new UnprocessableEntityException(validatorResult.Message);

            Ship? shipById = await _shipRepository.GetById(id);

            if (shipById == null)
            {
                throw new NotFoundItemException($"Ship not found by ID: {id}.");
            }

            shipById.Name = ship.Name;
            shipById.Code = ship.Code;
            shipById.Length = ship.Length;
            shipById.Width = ship.Width;

            return await _shipRepository.Update(shipById);
        }

        async Task<bool> IShipService.Delete(int id)
        {
            Ship? shipById = await _shipRepository.GetById(id);

            if (shipById == null)
            {
                throw new NotFoundItemException($"Ship not found by ID: {id}.");
            }

            return await _shipRepository.Delete(shipById);
        }

        async Task<List<Ship>> IShipService.GetAll(ShipFilter filter)
        {
            return await _shipRepository.GetAll(filter);
        }

        async Task<Ship?> IShipService.GetById(int id)
        {
            return await _shipRepository.GetById(id);
        }

        async Task<long> IShipService.CountAsync(ShipFilter filter)
        {
            return await _shipRepository.CountAsync(filter);
        }
    }
}