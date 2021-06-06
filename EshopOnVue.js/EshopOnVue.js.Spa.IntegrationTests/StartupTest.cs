using EshopOnVue.js.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EshopOnVue.js.Spa.IntegrationTests
{
    [TestClass]
    public class StartupTest
    {
        public static TestServer TestServer { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext _)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            //Hardcoded environment because Environment.GetEnvironmentVariable in test project not read Environment variable
            //https://github.com/aspnet/Tooling/issues/1089
            var environment = "Development";

            var webHostBuilder = new WebHostBuilder()
               .UseEnvironment(environment)
               .UseConfiguration(new ConfigurationBuilder()
               .AddJsonFile("appsettings.json")
               .Build());

            TestServer = new TestServer(webHostBuilder.UseStartup<Startup>());

            var dbContext = TestServer.Services.GetRequiredService<EshopContext>();

            if (dbContext.Database.IsSqlServer())
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }

            CatalogItemSeed.Seed(dbContext);
        }
    }
}
