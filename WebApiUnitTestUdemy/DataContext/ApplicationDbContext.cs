using Microsoft.EntityFrameworkCore;
using WebApiUnitTestUdemy.Models;

namespace WebApiUnitTestUdemy.DataContext
{
    public sealed class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        DbSet<Product> Products { get; set; }
    }
}
