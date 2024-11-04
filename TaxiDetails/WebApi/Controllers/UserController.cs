using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain.Repositories;
using AutoMapper;
using WebApi.DTO;
using TaxiDetails;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository<User, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех пользователей.
    /// </summary>
    /// <returns>Список всех пользователей и HTTP статус.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// Возвращает информацию о пользователе по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор нужного пользователя.</param>
    /// <returns>Объект пользователя и HTTP статус.</returns>
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = repository.Get(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    /// <summary>
    /// Добавляет нового пользователя в коллекцию.
    /// </summary>
    /// <param name="value">Экземпляр пользователя, который нужно добавить в коллекцию.</param>
    [HttpPost]
    public IActionResult Post([FromBody] UserDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = mapper.Map<User>(value);
        repository.Post(user);
        return Ok();
    }

    /// <summary>
    /// Заменяет пользователя с указанным идентификатором в коллекции.
    /// </summary>
    /// <param name="id">Идентификатор заменяемого пользователя.</param>
    /// <param name="value">Новый экземпляр пользователя, которым заменяется старый.</param>
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UserDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = mapper.Map<User>(value);
        user.Id = id;
        if (!repository.Put(user, id)) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Удаляет пользователя с указанным идентификатором из коллекции.
    /// </summary>
    /// <param name="id">Идентификатор удаляемого пользователя.</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
