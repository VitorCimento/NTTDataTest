using System.ComponentModel.DataAnnotations;
using NTTDataTest.Domain.Mappings.DTO.CartItem;

namespace NTTDataTest.Domain.Mappings.DTO.Cart;

public class CreateCartDTO
{
    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }

    [Required]
    public int userid { get; set; }

    public ICollection<CreateCartItemDTO> products { get; set; }
}
