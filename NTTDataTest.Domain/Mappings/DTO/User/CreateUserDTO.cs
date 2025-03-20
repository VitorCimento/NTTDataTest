using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Enums;
using NTTDataTest.Domain.Mappings.DTO.Address;
using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.User;

public class CreateUserDTO
{
    [Required, EmailAddress]
    public string email { get; set; }

    [Required, MaxLength(15)]
    public string username { get; set; }

    [Required, DataType(DataType.Password)]
    public string password { get; set; }

    [Required]
    public Name name { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public string phone { get; set; }

    [Required]
    public EUserStatus status { get; set; }

    [Required]
    public EUserRole role { get; set; }

    [Required]
    public CreateAddressDTO address { get; set; }
}
