using System;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }


        public DbSet<Blog> Blogs { get; set; }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
