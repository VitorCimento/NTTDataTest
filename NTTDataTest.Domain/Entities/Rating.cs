using Microsoft.EntityFrameworkCore;

namespace NTTDataTest.Domain.Entities;

[Owned]
public class Rating
{
    [Precision(5, 2)]
    public double rate { get; set; }
    public int count { get; set; }
}
