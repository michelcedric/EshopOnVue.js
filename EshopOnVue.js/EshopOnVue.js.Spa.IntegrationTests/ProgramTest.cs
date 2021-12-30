using EshopOnVue.js.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace EshopOnVue.js.Spa.IntegrationTests
{
    [TestClass]
    public class ProgramTest
    {
        public static HttpClient Client { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext _)
        {

            var application = new WebApplicationFactory<Program>();
            Client = application.CreateClient();

            using (var scope = application.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EshopContext>();

                if (dbContext.Database.IsSqlServer())
                {
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                }

                CatalogItemSeed.Seed(dbContext);
            }
        }
    }
}
