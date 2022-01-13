using Common;
using Image_Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestingWebAppFactory<T> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Data.Database>));

                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<Data.Database>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDB");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<Data.Database>())
                    {
                        try
                        {
                            File file = new Common.File() { Id = "99ff9bef-9c6b-41b6-ace2-991a73c10f63", Owner = "test", Path = "99ff9bef-9c6b-41b6-ace2-991a73c10f63.gif" };
                            appContext.Database.EnsureCreated();
                            appContext.Files.Add(file);
                            appContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            //Log errors
                            throw;
                        }

                    }
                }
            });
        }
    }
}
