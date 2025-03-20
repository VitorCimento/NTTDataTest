using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Context;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO;
using NTTDataTest.Domain.Mappings.DTO.User;

namespace NTTDataTest.ORM.Repositories;

public class UserRepository
{
    private readonly NTTContext _context;
    private IMapper _mapper;

    public UserRepository(NTTContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<User?> GetByIdAsync(int id) => await _context.Users.FirstOrDefaultAsync(x => x.id == id);

    public PagedDTO<ReadUserDTO> GetPaged(int page, int size, string order, string direction)
    {
        var totalItems = _context.Users.Count();

        var dbList = GetDbList(page,  size, order, direction);
        var returnDTO = GetPagedData(page, size, totalItems, dbList);

        return returnDTO;
    }

    private IQueryable<User> GetDbList(int page, int size, string order, string direction)
    {
        var skip = page - 1;

        Expression<Func<User, dynamic>> sortBy = order switch
        {
            nameof(User.id) => x => x.id,
            nameof(User.status) => x => x.status,
            nameof(User.username) => x => x.username,
            nameof(User.name) => x => x.name,
            nameof(User.email) => x => x.email,
            nameof(User.phone) => x => x.phone,
            _ => x => x.id
        };

        return direction == "asc"
            ? _context.Users
                .OrderBy(sortBy)
                .Skip(skip * size)
                .Take(size)
            : _context.Users
                .OrderByDescending(sortBy)
                .Skip(skip * size)
                .Take(size);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> PutAsync(int id, UpdateUserDTO userDTO)
    {
        var user = await GetByIdAsync(id);

        if (user == null) return null;

        _mapper.Map(userDTO, user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);

        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }

    private PagedDTO<ReadUserDTO> GetPagedData(int page, int size, int total, IQueryable dbList)
    {
        var totalPages = Convert.ToInt32(Math.Ceiling((decimal)total / (decimal)size));
        var dto = _mapper.Map<List<ReadUserDTO>>(dbList);

        return new PagedDTO<ReadUserDTO>
        {
            data = dto,
            currentPage = page,
            totalPages = totalPages,
            totalItems = total
        };
    }
}
