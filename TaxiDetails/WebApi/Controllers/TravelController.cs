using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain.Repositories;
using AutoMapper;
using WebApi.DTO;
using TaxiDetails;
namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TravelController(IRepository<Travel, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return travel
    /// </summary>
    /// <returns>list of travel and http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Travel>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// return information 
    /// </summary>
    /// <param name="id">identificator travel</param>
    /// <returns>object travel and http status</returns>
    [HttpGet("{id}")]
    public ActionResult<Travel> Get(int id)
    {
        var travel = repository.Get(id);

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
    public IActionResult Post([FromBody] TravelDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var travel = mapper.Map<Travel>(value);
        repository.Post(travel);
        return Ok();
    }

    /// <summary>
    /// replace travel 
    /// </summary>
    /// <param name="id">identificator of travel.</param>
    /// <param name="value">new object of travel</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TravelDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var travel = mapper.Map<Travel>(value);
        travel.Id = id;
        if (!repository.Put(travel, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удаляет поездку с указанным идентификатором из коллекции.
    /// </summary>
    /// <param name="id">identificator of travel</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
