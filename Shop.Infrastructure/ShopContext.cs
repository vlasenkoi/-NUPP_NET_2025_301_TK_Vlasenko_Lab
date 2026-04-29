using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Models;

namespace Shop.Infrastructure
{
    public class ShopContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=C:\Users\impos\OneDrive\Desktop\.net\lab1.net\lab1.net\shop.db");
        }
    }
}