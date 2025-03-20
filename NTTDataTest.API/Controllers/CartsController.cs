using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Cart;
using NTTDataTest.ORM.Repositories;

namespace NTTDataTest.API.Controllers;

[Route("[controller]")]
[ApiController]
public class CartsController : ControllerBase
{
    private CartRepository _repository;
    private IMapper _mapper;

    public CartsController(CartRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var cart = await _repository.GetByIdAsync(id);

        if (cart == null) return NotFound();

        return Ok(cart);
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
    public async Task<IActionResult> Post([FromBody] CreateCartDTO cartDTO)
    {
        var cart = _mapper.Map<Cart>(cartDTO);
        var createdCart = await _repository.CreateAsync(cart);

        return CreatedAtAction(nameof(Get), new { createdCart.id }, createdCart);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateCartDTO cartDTO)
    {
        var cart = await _repository.PutAsync(id, cartDTO);

        if (cart == null) return NotFound();

        return Ok(cart);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _repository.DeleteAsync(id);

        if (!response) return NotFound();

        return Ok(new { message = "User removed successfully!" });
    }
}
