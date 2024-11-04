using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain.Repositories;
using AutoMapper;
using WebApi.DTO;
using TaxiDetails;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriverController(IRepository<Driver, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех водителей.
    /// </summary>
    /// <returns>Список всех водителей и HTTP статус.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Driver>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает информацию о водителе по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор нужного водителя.</param>
    /// <returns>Объект водителя и HTTP статус.</returns>
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
    /// Добавляет нового водителя в коллекцию.
    /// </summary>
    /// <param name="value">Экземпляр водителя, который нужно добавить в коллекцию.</param>
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
    /// Заменяет водителя с указанным идентификатором в коллекции.
    /// </summary>
    /// <param name="id">Идентификатор заменяемого водителя.</param>
    /// <param name="value">Новый экземпляр водителя, которым заменяется старый.</param>
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
    /// Удаляет водителя с указанным идентификатором из коллекции.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого водителя.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
