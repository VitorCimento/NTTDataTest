using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Entities;

public class Cart
{
    [Key, Required]
    public int id { get; set; }

    [Required, DataType(DataType.DateTime)]
    public DateTime date { get; set; }

    public int userid { get; set; }

    public virtual User user { get; set; }

    public virtual ICollection<CartItem> products { get; set; }
}
