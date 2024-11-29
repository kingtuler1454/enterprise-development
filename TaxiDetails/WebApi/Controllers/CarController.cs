using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Repositories;
using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi.Controllers;

/// <summary>
/// Controller for managing cars.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CarController(IRepository<Car, int> carRepository, IRepository<Driver, int> driverRepository ,  IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return list of users
    /// </summary>
    /// <returns>list of user and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Car>>> Get()
    {
        return Ok(await carRepository.GetAll());
    }

    /// <summary>
    /// return car of identificator
    /// </summary>
    /// <param name="id">identificator of car</param>
    /// <returns>object of car and http.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Car>> Get(int id)
    {
        var car = await carRepository.Get(id);

        if (car == null)
        {
            return NotFound();
        }

        return Ok(car);
    }

    /// <summary>
    /// add new car 
    /// </summary>
    /// <param name="value">object of car.</param>
    [HttpPost]
    public async Task<ActionResult<Car>> Post([FromBody] CarDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var car = mapper.Map<Car>(value);
        var driver = await driverRepository.Get(value.AssignedDriverId);
        if (driver == null)
        {
            return BadRequest("Driver not found");
        }
        car.AssignedDriver = driver;
        var result = await carRepository.Post(car);
        return Ok(result);
    }

    /// <summary>
    /// replace car of identificator
    /// </summary>
    /// <param name="id">identificator of car</param>
    /// <param name="value">new exemplar of car.</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] CarDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var car = mapper.Map<Car>(value);
        var driver = await driverRepository.Get(value.AssignedDriverId);
        if (driver == null)
        {
            return BadRequest("Driver not found");
        }
        car.AssignedDriver = driver;
        var result = await carRepository.Put(car, id);
        if (!result) return NotFound();
        return Ok();
    }

    /// <summary>
    /// delete car
    /// </summary>
    /// <param name="id">identificator of delete car</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await carRepository.Delete(id);
        if (!result) return NotFound();
        return Ok();
    }
}
