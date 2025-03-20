using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.Cart;

public class CreateCartDTO
{
    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }
}
