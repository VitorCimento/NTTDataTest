using AutoMapper;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.User;

namespace NTTDataTest.Domain.Mappings.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, ReadUserDTO>();
        CreateMap<UpdateUserDTO, User>();
    }
}
