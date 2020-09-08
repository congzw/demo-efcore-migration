using System;
using System.IO;
using DemoApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    public static class Config
    {
        public static IServiceCollection CreateServiceCollection()
        {
            string dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllInOneContext.db");
            string connectionString = string.Format("Data Source={0}", dbFilePath);

            var services = new ServiceCollection();
                services
                    .AddDbContext<MainDbContext>(options => options.UseSqlite(connectionString, builder => builder.MigrationsAssembly("DemoApp")))
                .BuildServiceProvider();
            return services;
        }
    }
}
