﻿using Microsoft.EntityFrameworkCore;
using NTTDataTest.Domain.Entities;

namespace NTTDataTest.Domain.Context;

public class NTTContext : DbContext
{
    public NTTContext(DbContextOptions<NTTContext> ctxOpts) : base(ctxOpts) { }

    public DbSet<Product> Products { get; set; }
}
