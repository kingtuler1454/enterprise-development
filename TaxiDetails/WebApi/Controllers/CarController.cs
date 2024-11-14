using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain;
using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(IRepository<Car, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return list of users
    /// </summary>
    /// <returns>list of user and http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// return car of identificator
    /// </summary>
    /// <param name="id">identificator of car</param>
    /// <returns>object of car and http.</returns>
    [HttpGet("{id}")]
    public ActionResult<Car> Get(int id)
    {
        var car = repository.Get(id);

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
    public IActionResult Post([FromBody] CarDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var car = mapper.Map<Car>(value);
        repository.Post(car);
        return Ok();
    }

    /// <summary>
    /// replace car of identificator
    /// </summary>
    /// <param name="id">identificator of car</param>
    /// <param name="value">new exemplar of car.</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CarDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var car = mapper.Map<Car>(value);
        car.Id = id;
        if (!repository.Put(car, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// delete car
    /// </summary>
    /// <param name="id">identificator of delete car</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
