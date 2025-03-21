using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Entities;

public class CartItem
{
    [Key, Required]
    public int id { get; set; }

    [Required]
    public int quantity { get; set; }

    public int cartid { get; set; }

    public int productid { get; set; }

    public virtual Cart cart { get; set; }

    public virtual Product product { get; set; }
}
