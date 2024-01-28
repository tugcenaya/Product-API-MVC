﻿using Microsoft.EntityFrameworkCore;
using Project.API.Models.Products;

namespace Project.API.Models;
public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{
	}
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)"); // Adjust precision and scale as needed
    }
}