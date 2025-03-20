using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.Cart;

public class UpdateCartDTO
{
    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }
}
