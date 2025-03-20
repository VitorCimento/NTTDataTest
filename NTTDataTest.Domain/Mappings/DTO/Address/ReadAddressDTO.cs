using NTTDataTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.Address;

public class ReadAddressDTO
{
    public int id { get; set; }

    public string city { get; set; }

    public string street { get; set; }

    public int number { get; set; }

    public string zipcode { get; set; }

    public Geolocation geolocation { get; set; }
}
