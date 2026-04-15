using FoodModel;
using Microsoft.EntityFrameworkCore;

namespace FoodMenuDbFile
{
    public class FoodMenuDb : DbContext
    {
        public FoodMenuDb(DbContextOptions<FoodMenuDb> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
    }
}