using NTTDataTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.Address;

public class UpdateAddressDTO
{
    [Required, MaxLength(50)]
    public string city { get; set; }

    [Required, MaxLength(100)]
    public string street { get; set; }

    public int number { get; set; }

    [Required, MaxLength(8), DataType(DataType.PostalCode)]
    public string zipcode { get; set; }

    public Geolocation geolocation { get; set; }
}
