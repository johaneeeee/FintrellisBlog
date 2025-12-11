using Microsoft.EntityFrameworkCore;
using FintrellisBlogApi.Entities;

namespace FintrellisBlogApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts => Set<Post>();
    }
}