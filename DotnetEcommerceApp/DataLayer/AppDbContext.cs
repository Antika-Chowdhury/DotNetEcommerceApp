
using DotnetEcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetEcommerceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}