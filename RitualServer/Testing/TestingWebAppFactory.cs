using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using RitualServer.Model;

namespace RitualServer.Testing
{
//    public class TestingWebAppFactory<TEntryPoint> :
//WebApplicationFactory<Program> where TEntryPoint : Program
//    {
//        protected override void ConfigureWebHost(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices(services =>
//            {
//                var descriptor = services.SingleOrDefault(
//                d => d.ServiceType == typeof(DbContextOptions<RitualbdContext>));
//                if (descriptor != null)
//                    services.Remove(descriptor);
//                services.AddDbContext<RitualbdContext>(options =>
//                {
//                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
//                });
//                var sp = services.BuildServiceProvider();
//                using (var scope = sp.CreateScope())
//                using (var appContext =
//                scope.ServiceProvider.GetRequiredService<RitualbdContext>())
//                {
//                    try
//                    {
//                        appContext.Database.EnsureCreated();
//                        Seed(appContext);
//                    }
//                    catch (Exception ex)
//                    {
//                        throw;
//                    }
//                }
//            });

//        }
//        private void Seed(RitualbdContext context)
//        {
//            var categories = new[]
//         {
//            new Category { CategoryId = 1, Name = "Category 1" },
//            new Category { CategoryId = 2, Name = "Category 2" },
//            new Category { CategoryId = 3, Name = "Category 3" }
//        };
//            context.Categories.AddRange(categories);
//            context.SaveChanges();
//        }
//    }
}
