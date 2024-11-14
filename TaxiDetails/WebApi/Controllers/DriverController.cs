using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain;
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
    public ActionResult<IEnumerable<Driver>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// return driver of identificator
    /// </summary>
    /// <param name="id">identificator of driver</param>
    /// <returns>Object of driver and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Driver> Get(int id)
    {
        var driver = repository.Get(id);

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
    public IActionResult Post([FromBody] DriverDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var driver = mapper.Map<Driver>(value);
        repository.Post(driver);
        return Ok();
    }

    /// <summary>
    /// replace driver of identificator.
    /// </summary>
    /// <param name="id">identificator of driver</param>
    /// <param name="value">new driver</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] DriverDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var driver = mapper.Map<Driver>(value);
        driver.Id = id;
        if (!repository.Put(driver, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// delete driver of collection
    /// </summary>
    /// <param name="id">identificator of driver</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
