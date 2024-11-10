using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Domain;
using AutoMapper;
using TaxiDetails.WebApi.DTO;
using TaxiDetails;

namespace TaxiDetails.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository<User, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return list user
    /// </summary>
    /// <returns>list user and http status</returns>
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return Ok(repository.GetAll());
    }

    /// <summary>
    /// information of user 
    /// </summary>
    /// <param name="id">identificator of user</param>
    /// <returns>object user and http status</returns>
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
    /// add user 
    /// </summary>
    /// <param name="value">object of user </param>
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
    /// replace user
    /// </summary>
    /// <param name="id">identificator  of user</param>
    /// <param name="value">new user</param>
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
    /// delete user
    /// </summary>
    /// <param name="id">identificator user</param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!repository.Delete(id)) return NotFound();
        return Ok();
    }
}
