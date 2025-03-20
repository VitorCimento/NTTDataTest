using AutoMapper;
using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Mappings.DTO.Address;

namespace NTTDataTest.Domain.Mappings.Profiles;

public class AddressProfile :Profile
{
    public AddressProfile()
    {
        CreateMap<CreateAddressDTO, Address>();
        CreateMap<UpdateAddressDTO, Address>();
        CreateMap<Address, ReadAddressDTO>();
    }
}
