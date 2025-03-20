using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Product;
using NTTDataTest.ORM.Repositories;

namespace NTTDataTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private ProductRepository _repository;
    private IMapper _mapper;

    public ProductsController(ProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductDTO productDTO)
    {
        var product = _mapper.Map<Product>(productDTO);
        var createdProduct = await _repository.CreateAsync(product);

        return CreatedAtAction(nameof(Get), new { createdProduct.id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProductDTO productDTO)
    {
        var product = await _repository.PutAsync(id, productDTO);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await _repository.DeleteAsync(id);

        if (!response) return NotFound();

        return Ok(new { message = "Product removed successfully!" });
    }

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        var response = _repository.GetCategories();

        if (response == null || response.Count() == 0) return NotFound();

        return Ok(response);
    }

    [HttpGet("categories/{category}")]
    public IActionResult ProductsByCategory([FromRoute] string category, [FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string order = "id")
    {
        var split = order.Split(" ");
        var newOrder = split[0];
        var direction = split.Length > 1 ? split[1] : "asc";

        var paged = _repository.GetByCategory(category, page, size, newOrder, direction);

        return Ok(paged);
    }

}
