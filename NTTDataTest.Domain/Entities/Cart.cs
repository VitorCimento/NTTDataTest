using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Entities;

public class Cart
{
    [Key, Required]
    public int id { get; set; }

    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }
}
