using Microsoft.EntityFrameworkCore;
using System;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Context
{
    public class ECommerceDbContext:DbContext
    {
        public ECommerceDbContext(DbContextOptions option) : base(option)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
