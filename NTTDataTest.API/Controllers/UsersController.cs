using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Product;
using NTTDataTest.Domain.Mappings.DTO.User;
using NTTDataTest.ORM.Repositories;

namespace NTTDataTest.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private UserRepository _repository;
    private IMapper _mapper;

    public UsersController(UserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var user = await _repository.GetByIdAsync(id);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string order = "id")
    {
        var split = order.Split(" ");
        var newOrder = split[0];
        var direction = split.Length > 1 ? split[1] : "asc";

        var paged = _repository.GetPaged(page, size, newOrder, direction);

        return Ok(paged);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserDTO userDTO)
    {
        var user = _mapper.Map<User>(userDTO);
        var createdUser = await _repository.CreateAsync(user);

        return CreatedAtAction(nameof(Get), new { createdUser.id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateUserDTO userDTO)
    {
        var user = await _repository.PutAsync(id, userDTO);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _repository.DeleteAsync(id);

        if (!response) return NotFound();

        return Ok(new { message = "User removed successfully!" });
    }
}
