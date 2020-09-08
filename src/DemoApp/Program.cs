using System;
using System.Linq;
using DemoApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Config.CreateServiceCollection().BuildServiceProvider();
            var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();


            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var provider = serviceScope.ServiceProvider;
                var mainDbContext = provider.GetService<MainDbContext>();

                mainDbContext.Database.Migrate();

                var count = mainDbContext.Blogs.Count();
                Console.WriteLine(count);
            }
            Console.Read();
        }
    }
}
