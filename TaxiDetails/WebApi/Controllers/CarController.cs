using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain.Repositories;
using AutoMapper;
using TaxiDetails;
using WebApi.DTO;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController(IRepository<Car, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех автомобилей.
    /// </summary>
    /// <returns>Список всех автомобилей и HTTP статус.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает автомобиль по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор нужного автомобиля.</param>
    /// <returns>Объект автомобиля и HTTP статус.</returns>
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
    /// Добавляет новый автомобиль в коллекцию.
    /// </summary>
    /// <param name="value">Экземпляр автомобиля, который нужно добавить в коллекцию.</param>
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
    /// Заменяет автомобиль с указанным идентификатором в коллекции.
    /// </summary>
    /// <param name="id">Идентификатор заменяемого автомобиля.</param>
    /// <param name="value">Новый экземпляр автомобиля, которым заменяется старый.</param>
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
    /// Удаляет автомобиль с указанным идентификатором из коллекции.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого автомобиля.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
