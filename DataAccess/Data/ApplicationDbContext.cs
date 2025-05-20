using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RedisService.Models;

namespace RedisService.DataAccess.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }      
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ProductBatch> ProductBatches { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
