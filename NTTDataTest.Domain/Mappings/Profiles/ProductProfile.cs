using AutoMapper;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Product;

namespace NTTDataTest.Domain.Mappings.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDTO, Product>();
        CreateMap<Product, ReadProductDTO>();
        CreateMap<UpdateProductDTO, Product>();
    }
}
