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

                //var databaseCreator = _authDbContext.GetService<IRelationalDatabaseCreator>();
                //var generateCreateScript = databaseCreator.GenerateCreateScript();
                //var exists = databaseCreator.Exists();

                var migrations = mainDbContext.Database.GetMigrations().ToList();
                Console.WriteLine("GetMigrations: "  + migrations.Count);
                foreach (var migration in migrations)
                {
                    Console.WriteLine(migration);
                }

                var appliedMigrations = mainDbContext.Database.GetAppliedMigrations().ToList();
                Console.WriteLine("GetAppliedMigrations: " + appliedMigrations.Count);
                foreach (var migration in appliedMigrations)
                {
                    Console.WriteLine(migration);
                }
                
                var pendingMigrations = mainDbContext.Database.GetPendingMigrations().ToList();
                Console.WriteLine("GetPendingMigrations: " + pendingMigrations.Count);
                foreach (var pendingMigration in pendingMigrations)
                {
                    Console.WriteLine(pendingMigration);
                }

                mainDbContext.Database.Migrate();

                var count = mainDbContext.Blogs.Count();
                Console.WriteLine("query blogs count: " + count);
            }
            Console.Read();
        }
    }
}
