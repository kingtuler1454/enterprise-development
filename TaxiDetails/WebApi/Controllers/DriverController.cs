using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Repositories;
using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi.Controllers;

/// <summary>
/// Controller for managing drivers.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class DriverController(IRepository<Driver, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return all drivers
    /// </summary>
    /// <returns>list of drivers and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Driver>>> Get()
    {
        return Ok(await repository.GetAll());
    }

    /// <summary>
    /// return driver of identificator
    /// </summary>
    /// <param name="id">identificator of driver</param>
    /// <returns>Object of driver and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> Get(int id)
    {
        var driver = await repository.Get(id);

        if (driver == null)
        {
            return NotFound();
        }

        return Ok(driver);
    }

    /// <summary>
    ///add new driver
    /// </summary>
    /// <param name="value">Object of driver for add</param>
    [HttpPost]
    public async Task<ActionResult<Driver>> Post([FromBody] DriverDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var driver = mapper.Map<Driver>(value);
        var result = await repository.Post(driver);
        return Ok(result);
    }

    /// <summary>
    /// replace driver of identificator.
    /// </summary>
    /// <param name="id">identificator of driver</param>
    /// <param name="value">new driver</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] DriverDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var driver = mapper.Map<Driver>(value);
        var result = await repository.Put(driver, id);
        if (!result) return NotFound();
        return Ok();
    }

    /// <summary>
    /// delete driver of collection
    /// </summary>
    /// <param name="id">identificator of driver</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Delete(id);
        if (!result) return NotFound();
        return Ok();
    }
}
