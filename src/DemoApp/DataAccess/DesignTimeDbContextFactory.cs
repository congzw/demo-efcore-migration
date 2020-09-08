using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DemoApp.DataAccess
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainDbContext>
    {
        public MainDbContext CreateDbContext(string[] args)
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllInOneContext.db");
            string connectionString = string.Format("Data Source={0}", dbFilePath);

            var dbContextBuilder = new DbContextOptionsBuilder<MainDbContext>();
            dbContextBuilder.UseSqlite(connectionString);

            return new MainDbContext(dbContextBuilder.Options);
        }
    }
}