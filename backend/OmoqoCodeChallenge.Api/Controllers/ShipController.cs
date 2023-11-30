using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OmoqoCodeChallenge.Api.DTOs;
using OmoqoCodeChallenge.Api.GlobalExceptionHandler;
using OmoqoCodeChallenge.Application.Interfaces;
using OmoqoCodeChallenge.Application.Models;
using OmoqoCodeChallenge.Domain.Entities;

namespace OmoqoCodeChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly IShipService _shipService;
        private readonly IMapper _mapper;

        public ShipController(IShipService shipService, IMapper mapper)
        {
            _shipService = shipService;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a Ship by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ship detail</returns>
        /// <response code="200">Return object **ShipResponseDTO**.</response>
        /// <response code="500">Return object **ApiErrorResponse**.</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ShipResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Ship>> GetById(int id)
        {
            Ship? ship = await _shipService.GetById(id);
            return Ok(ship == null ? new() : _mapper.Map<Ship, ShipResponseDTO>(ship));
        }

        /// <summary>
        /// Returns a paged list of ship 
        /// </summary>
        /// <params>shipFilterDTO</params>
        /// <returns>Ship list</returns>
        /// <response code="200">Return object **ShipListPaggingDTO**.</response>
        /// <response code="500">Return object **ApiErrorResponse**.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<ShipListPaggingDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ShipListPaggingDTO>>> GetAllAsync([FromQuery] ShipFilterDTO shipFilterDTO)
        {
            ShipFilter shipFilter = _mapper.Map<ShipFilterDTO, ShipFilter>(shipFilterDTO);

            List<Ship> ships = await _shipService.GetAll(shipFilter);
            long count = await _shipService.CountAsync(shipFilter);

            List<ShipResponseDTO> results = _mapper.Map<List<Ship>, List<ShipResponseDTO>>(ships);

            return Ok(new ShipListPaggingDTO
            {
                Data = results,
                Count = count,
                Page = shipFilter.Page,
                Limit = shipFilter.Limit,
            });
        }

        /// <summary>
        /// Register a new Ship
        /// </summary>
        /// <param name="shipDTO"></param>
        /// <returns>Created item response</returns>
        /// <response code="200">Return object **ShipResponseDTO**.</response>
        /// <response code="422">Return object **ApiErrorResponse**.</response>
        /// <response code="500">Return object **ApiErrorResponse**.</response>
        [HttpPost]
        [ProducesResponseType(typeof(ShipResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShipResponseDTO>> Create([FromBody] ShipCreateDTO shipDTO)
        {
            Ship ship = await _shipService.Create(_mapper.Map<ShipCreateDTO, Ship>(shipDTO));
            return Ok(_mapper.Map<Ship, ShipResponseDTO>(ship));
        }

        /// <summary>
        /// Update a Ship
        /// </summary>
        /// <param name="shipDTO"></param>
        /// <param name="id"></param>
        /// <returns>Updated item response</returns>
        /// <response code="200">Return object **ShipResponseDTO**.</response>
        /// <response code="404">Return object **ApiErrorResponse**.</response>
        /// <response code="422">Return object **ApiErrorResponse**.</response>
        /// <response code="500">Return object **ApiErrorResponse**.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ShipResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Ship>> Update([FromBody] ShipUpdateDTO shipDTO, int id)
        {
            Ship ship = await _shipService.Update(_mapper.Map<ShipUpdateDTO, Ship>(shipDTO), id);
            return Ok(_mapper.Map<Ship, ShipResponseDTO>(ship));
        }

        /// <summary>
        /// Delete a Ship by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a deletion status</returns>
        /// <response code="200">Return object **ShipResponseDTO**.</response>
        /// <response code="404">Return object **ApiErrorResponse**.</response>
        /// <response code="500">Return object **ApiErrorResponse**.</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ship>> Delete(int id)
        {
            bool deleted = await _shipService.Delete(id);
            return Ok(deleted);
        }
    }
}
