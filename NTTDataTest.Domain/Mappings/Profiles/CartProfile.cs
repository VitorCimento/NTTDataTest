using AutoMapper;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Cart;

namespace NTTDataTest.Domain.Mappings.Profiles;

public class CartProfile : Profile
{
    public CartProfile()
    {
        CreateMap<CreateCartDTO, Cart>();
        CreateMap<UpdateCartDTO, Cart>();
        CreateMap<Cart, ReadCartDTO>();
    }
}
