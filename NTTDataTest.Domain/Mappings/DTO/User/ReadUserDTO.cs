using NTTDataTest.Domain.Entities;
using NTTDataTest.Domain.Enums;

namespace NTTDataTest.Domain.Mappings.DTO.User;

public class ReadUserDTO
{
    public int id { get; set; }

    public string email { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public Name name { get; set; }

    public string phone { get; set; }

    public EUserStatus status { get; set; }

    public EUserRole role { get; set; }
}
