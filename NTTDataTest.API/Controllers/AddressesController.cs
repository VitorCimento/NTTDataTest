using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Address;
using NTTDataTest.ORM.Repositories;

namespace NTTDataTest.API.Controllers;

[Route("[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private AddressRepository _repository;
    private IMapper _mapper;

    public AddressesController(AddressRepository repository, IMapper mapper)
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
    public async Task<IActionResult> Post([FromBody] CreateAddressDTO addressDTO)
    {
        var address = _mapper.Map<Address>(addressDTO);
        var createdAddress = await _repository.CreateAsync(address);

        return CreatedAtAction(nameof(Get), new { createdAddress.id }, createdAddress);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateAddressDTO addressDTO)
    {
        var address = await _repository.PutAsync(id, addressDTO);

        if (address == null) return NotFound();

        return Ok(address);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _repository.DeleteAsync(id);

        if (!response) return NotFound();

        return Ok(new { message = "User removed successfully!" });
    }
}
