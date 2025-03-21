using AutoMapper;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.CartItem;

namespace NTTDataTest.Domain.Mappings.Profiles;

public class CartItemProfile : Profile
{
    public CartItemProfile()
    {
        CreateMap<CreateCartItemDTO, CartItem>();
        CreateMap<UpdateCartItemDTO, CartItem>();
        CreateMap<CartItem, ReadCartItemDTO>();
    }
}
