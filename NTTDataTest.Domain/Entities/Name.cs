using Microsoft.EntityFrameworkCore;

namespace NTTDataTest.Domain.Entities;

[Owned]
public class Name
{
    public string firstname { get; set; }
    public string lastname { get; set; }
}
