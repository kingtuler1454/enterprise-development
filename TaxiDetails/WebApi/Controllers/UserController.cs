using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiDetails.Repositories;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi.Controllers;

/// <summary>
/// Controller for managing users.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UserController(IRepository<User, int> repository, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// return list user
    /// </summary>
    /// <returns>list user and http status</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        return Ok(await repository.GetAll());
    }

    /// <summary>
    /// information of user 
    /// </summary>
    /// <param name="id">identificator of user</param>
    /// <returns>object user and http status</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await repository.Get(id);

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
    public async Task<ActionResult<User>> Post([FromBody] UserDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = mapper.Map<User>(value);
        var result = await repository.Post(user);
        return Ok(result);
    }

    /// <summary>
    /// replace user
    /// </summary>
    /// <param name="id">identificator  of user</param>
    /// <param name="value">new user</param>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UserDto value)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = mapper.Map<User>(value);
        var result = await repository.Put(user, id);
        if (!result) return NotFound();
        return Ok();
    }

    /// <summary>
    /// delete user
    /// </summary>
    /// <param name="id">identificator user</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await repository.Delete(id);
        if (!result) return NotFound();
        return Ok();
    }
}
