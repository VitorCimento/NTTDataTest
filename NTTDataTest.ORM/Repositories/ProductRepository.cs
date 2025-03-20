using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Context;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO;
using NTTDataTest.Domain.Mappings.DTO.Product;

namespace NTTDataTest.ORM.Repositories;

public class ProductRepository
{
    private readonly NTTContext _context;
    private IMapper _mapper;

    public ProductRepository(NTTContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public PagedDTO<ReadProductDTO> GetPaged(int page, int size, string order, string direction)
    {
        var totalItems = _context.Products.Count();
        var skip = page - 1;

        var dbList = GetDbList(page, size, order, direction);
        var returnDTO = GetPagedData(page, size, totalItems, dbList);

        return returnDTO;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(x => x.id == id);
    } 

    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> PutAsync(int id, UpdateProductDTO productDTO)
    {
        var product = await GetByIdAsync(id);

        if (product == null) return null;

        _mapper.Map(productDTO, product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await GetByIdAsync(id);

        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public IEnumerable<string> GetCategories() => _context.Products.OrderBy(x => x.category).Select(x => x.category).Distinct().ToList();

    public PagedDTO<ReadProductDTO> GetByCategory(string category, int page, int size, string order, string direction)
    {
        Expression<Func<Product, bool>> where = x => x.category.ToLower() == category.ToLower();

        var totalItems = _context.Products.Count(where);
        var skip = page - 1;

        var dbList = GetDbList(page, size, order, direction).Where(where);
        var returnDTO = GetPagedData(page, size, totalItems, dbList);

        return returnDTO;
    }

    private IQueryable<Product> GetDbList(int page, int size, string order, string direction)
    {
        var skip = page - 1;

        Expression<Func<Product, dynamic>> sortBy = order switch
        {
            nameof(Product.id) => x => x.id,
            nameof(Product.title) => x => x.title,
            nameof(Product.price) => x => x.price,
            nameof(Product.description) => x => x.description,
            nameof(Product.category) => x => x.category,
            nameof(Product.image) => x => x.image,
            _ => x => x.id
        };

        return direction == "asc"
            ? _context.Products
                .OrderBy(sortBy)
                .Skip(skip * size)
                .Take(size)
            : _context.Products
                .OrderByDescending(sortBy)
                .Skip(skip * size)
                .Take(size);
    }

    private PagedDTO<ReadProductDTO> GetPagedData(int page, int size, int total, IQueryable dbList)
    {
        var totalPages = Convert.ToInt32(Math.Ceiling((decimal)total / (decimal)size));
        var dto = _mapper.Map<List<ReadProductDTO>>(dbList);

        return new PagedDTO<ReadProductDTO>
        {
            data = dto,
            currentPage = page,
            totalPages = totalPages,
            totalItems = total
        };
    }
}
