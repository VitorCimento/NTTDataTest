using Microsoft.EntityFrameworkCore;

namespace NTTDataTest.Domain.Entities;

[Owned]
public class Geolocation
{
    public string lat { get; set; }
    public string lng { get; set; }
}
