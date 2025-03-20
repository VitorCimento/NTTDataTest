using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NTTDataTest.Domain.Mappings.DTO.Product;

public class CreateProductDTO
{
    [Required]
    [StringLength(30)]
    public string title { get; set; }
    [Required]
    [Precision(10, 2)]
    public double price { get; set; }
    [Required]
    [StringLength(100)]
    public string description { get; set; }
    [Required]
    [StringLength(50)]
    public string category { get; set; }
    public string image { get; set; }
    public Rating rating { get; set; }
}
