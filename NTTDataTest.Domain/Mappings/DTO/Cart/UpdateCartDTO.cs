using System.ComponentModel.DataAnnotations;
using NTTDataTest.Domain.Mappings.DTO.CartItem;

namespace NTTDataTest.Domain.Mappings.DTO.Cart;

public class UpdateCartDTO
{
    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }

    [Required]
    public int userid { get; set; }

    public ICollection<UpdateCartItemDTO> products { get; set; }
}
