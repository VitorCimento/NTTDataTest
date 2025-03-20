using AutoMapper;
using NTTDataTest.Domain.Context;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Mappings.DTO.Cart;

namespace NTTDataTest.ORM.Repositories;

public class CartRepository
{
    private readonly NTTContext _context;
    private IMapper _mapper;

    public CartRepository(NTTContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Cart?> GetByIdAsync(int id) => await _context.Carts.FirstOrDefaultAsync(x => x.id == id);

    public PagedDTO<ReadCartDTO> GetPaged(int page, int size, string order, string direction)
    {
        var totalItems = _context.Carts.Count();

        var dbList = GetDbList(page, size, order, direction);
        var returnDTO = GetPagedData(page, size, totalItems, dbList);

        return returnDTO;
    }

    public async Task<Cart> CreateAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
        return cart;
    }

    public async Task<Cart?> PutAsync(int id, UpdateCartDTO cartDTO)
    {
        var cart = await GetByIdAsync(id);

        if (cart == null) return null;

        _mapper.Map(cartDTO, cart);
        await _context.SaveChangesAsync();

        return cart;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var cart = await GetByIdAsync(id);

        if (cart == null) return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();

        return true;
    }

    private PagedDTO<ReadCartDTO> GetPagedData(int page, int size, int total, IQueryable dbList)
    {
        var totalPages = Convert.ToInt32(Math.Ceiling((decimal)total / (decimal)size));
        var dto = _mapper.Map<List<ReadCartDTO>>(dbList);

        return new PagedDTO<ReadCartDTO>
        {
            data = dto,
            currentPage = page,
            totalPages = totalPages,
            totalItems = total
        };
    }

    private IQueryable<Cart> GetDbList(int page, int size, string order, string direction)
    {
        var skip = page - 1;

        Expression<Func<Cart, dynamic>> sortBy = order switch
        {
            nameof(Cart.id) => x => x.id,
            nameof(Cart.date) => x => x.date,
            _ => x => x.id
        };

        return direction == "asc"
            ? _context.Carts
                .OrderBy(sortBy)
                .Skip(skip * size)
                .Take(size)
            : _context.Carts
                .OrderByDescending(sortBy)
                .Skip(skip * size)
                .Take(size);
    }
}
