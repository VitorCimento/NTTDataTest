using NTTDataTest.Domain.Entities;

namespace NTTDataTest.Domain.Mappings.DTO.Product;

public class ReadProductDTO
{
    public int id { get; set; }
    public string title { get; set; }
    public double price { get; set; }
    public string description { get; set; }
    public string category { get; set; }
    public string image { get; set; }
    public Rating rating { get; set; }
}
