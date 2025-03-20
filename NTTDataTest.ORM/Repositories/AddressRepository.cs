using System.Linq.Expressions;
using AutoMapper;
using NTTDataTest.Domain.Context;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO;
using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Mappings.DTO.Address;

namespace NTTDataTest.ORM.Repositories;

public class AddressRepository
{
    private readonly NTTContext _context;
    private IMapper _mapper;

    public AddressRepository(NTTContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Address?> GetByIdAsync(int id) => await _context.Addresses.FirstOrDefaultAsync(x => x.id == id);

    public PagedDTO<ReadAddressDTO> GetPaged(int page, int size, string order, string direction)
    {
        var totalItems = _context.Addresses.Count();

        var dbList = GetDbList(page, size, order, direction);
        var returnDTO = GetPagedData(page, size, totalItems, dbList);

        return returnDTO;
    }

    public async Task<Address> CreateAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task<Address?> PutAsync(int id, UpdateAddressDTO userDTO)
    {
        var address = await GetByIdAsync(id);

        if (address == null) return null;

        _mapper.Map(userDTO, address);
        await _context.SaveChangesAsync();

        return address;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var address = await GetByIdAsync(id);

        if (address == null) return false;

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();

        return true;
    }

    private IQueryable<Address> GetDbList(int page, int size, string order, string direction)
    {
        var skip = page - 1;

        Expression<Func<Address, dynamic>> sortBy = order switch
        {
            nameof(Address.id) => x => x.id,
            nameof(Address.city) => x => x.city,
            nameof(Address.number) => x => x.number,
            nameof(Address.street) => x => x.street,
            nameof(Address.zipcode) => x => x.zipcode,
            _ => x => x.id
        };

        return direction == "asc"
            ? _context.Addresses
                .OrderBy(sortBy)
                .Skip(skip * size)
                .Take(size)
            : _context.Addresses
                .OrderByDescending(sortBy)
                .Skip(skip * size)
                .Take(size);
    }

    private PagedDTO<ReadAddressDTO> GetPagedData(int page, int size, int total, IQueryable dbList)
    {
        var totalPages = Convert.ToInt32(Math.Ceiling((decimal)total / (decimal)size));
        var dto = _mapper.Map<List<ReadAddressDTO>>(dbList);

        return new PagedDTO<ReadAddressDTO>
        {
            data = dto,
            currentPage = page,
            totalPages = totalPages,
            totalItems = total
        };
    }
}
