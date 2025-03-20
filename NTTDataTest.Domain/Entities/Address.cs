using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Entities;

public class Address
{
    [Key, Required]
    public int id { get; set; }

    [Required, MaxLength(50)]
    public string city { get; set; }

    [Required, MaxLength(100)]
    public string street { get; set; }

    public int number { get; set; }

    [Required, MaxLength(8), DataType(DataType.PostalCode)]
    public string zipcode { get; set; }

    public Geolocation geolocation { get; set; }
}
