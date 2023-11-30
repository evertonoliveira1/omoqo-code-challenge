using AutoMapper;
using OmoqoCodeChallenge.Api.DTOs;
using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Api.Mappers
{
    public class ShipMapperProfile : Profile
    {
        public ShipMapperProfile()
        {
            CreateMap<Ship, ShipResponseDTO>();
            CreateMap<Ship, ShipListPaggingDTO>();
            CreateMap<ShipUpdateDTO, Ship>();
            CreateMap<ShipCreateDTO, Ship>();
            CreateMap<Ship, ShipResponseDTO>();
            CreateMap<Ship, ShipListPaggingDTO>();
            CreateMap<ShipFilterDTO, ShipFilter>();
        }
    }
}