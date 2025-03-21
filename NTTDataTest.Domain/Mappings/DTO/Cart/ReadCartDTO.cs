using System.ComponentModel.DataAnnotations;
using NTTDataTest.Domain.Mappings.DTO.CartItem;

namespace NTTDataTest.Domain.Mappings.DTO.Cart;

public class ReadCartDTO
{
    public int id { get; set; }

    public DateTime date { get; set; }

    public int userid { get; set; }

    public ICollection<ReadCartItemDTO> products { get; set; }
}
