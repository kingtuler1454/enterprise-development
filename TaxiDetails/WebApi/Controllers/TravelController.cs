using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Repositories;
using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi.Controllers;

/// <summary>
/// Controller for managing travels.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TravelController(IRepository<Travel, int> travelRepository, IRepository<Car, int> carRepository, IRepository<User, int> userRepository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return travel
    /// </summary>
    /// <returns>list of travel and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Travel>>> Get()
    {
        return Ok(await travelRepository.GetAll());
    }

    /// <summary>
    /// return information 
    /// </summary>
    /// <param name="id">identificator travel</param>
    /// <returns>object travel and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Travel>> Get(int id)
    {
        var travel = await travelRepository.Get(id);

        if (travel == null)
        {
            return NotFound();
        }

        return Ok(travel);
    }

    /// <summary>
    /// add new trip
    /// </summary>
    /// <param name="value">object travel</param>
    [HttpPost]
    public async Task<ActionResult<Travel>> Post([FromBody] TravelDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var travel = mapper.Map<Travel>(value);
        var car = await carRepository.Get(value.AssignedCarId);
        var user = await userRepository.Get(value.ClientId);
        if (user == null || car == null)
        {
            return BadRequest("Incorrect ids");
        }
        travel.AssignedCar = car;
        travel.Client = user;
        var result = await travelRepository.Post(travel);
        return Ok(result);
    }

    /// <summary>
    /// replace travel 
    /// </summary>
    /// <param name="id">identificator of travel.</param>
    /// <param name="value">new object of travel</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TravelDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var travel = mapper.Map<Travel>(value);
        var car = await carRepository.Get(value.AssignedCarId);
        var user = await userRepository.Get(value.ClientId);
        if (user == null || car == null)
        {
            return BadRequest("Incorrect ids");
        }
        travel.AssignedCar = car;
        travel.Client = user;
        var result = await travelRepository.Put(travel, id);
        if (!result) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удаляет поездку с указанным идентификатором из коллекции.
    /// </summary>
    /// <param name="id">identificator of travel</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await travelRepository.Delete(id);
        if (!result) return NotFound();
        return Ok();
    }
}
