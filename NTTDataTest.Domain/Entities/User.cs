using System.ComponentModel.DataAnnotations;
using NTTDataTest.Domain.Enums;

namespace NTTDataTest.Domain.Entities;

public class User
{
    [Key, Required]
    public int id { get; set; }

    [Required, EmailAddress]
    public string email { get; set; }

    [Required, MaxLength(15)]
    public string username { get; set; }

    [Required, DataType(DataType.Password)]
    public string password { get; set; }

    [Required]
    public Name name { get; set; }

    [Required, DataType(DataType.PhoneNumber)]
    public string phone { get; set; }

    [Required]
    public EUserStatus status { get; set; }

    [Required]
    public EUserRole role { get; set; }
}
