using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NTTDataTest.Domain.Entities;

public class Product
{
    [Key]
    [Required]
    public int id { get; set; }

    [Required]
    [MaxLength(30)]
    public string title { get; set; }

    [Required]
    [Precision(10, 2)]
    public double price { get; set; }

    [Required]
    [MaxLength(100)]
    public string description { get; set; }

    [Required]
    [MaxLength(50)]
    public string category { get; set; }

    public string image { get; set; }

    public Rating rating { get; set; }
}
