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
    /// Возвращает список всех поездок.
    /// </summary>
    /// <returns>Список всех поездок и HTTP статус.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Travel>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает информацию о поездке по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор нужной поездки.</param>
    /// <returns>Объект поездки и HTTP статус.</returns>
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
    /// Добавляет новую поездку в коллекцию.
    /// </summary>
    /// <param name="value">Экземпляр поездки, который нужно добавить в коллекцию.</param>
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
    /// Заменяет поездку с указанным идентификатором в коллекции.
    /// </summary>
    /// <param name="id">Идентификатор заменяемой поездки.</param>
    /// <param name="value">Новый экземпляр поездки, которым заменяется старая.</param>
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
    /// <param name="id">Идентификатор удаляемой поездки.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
