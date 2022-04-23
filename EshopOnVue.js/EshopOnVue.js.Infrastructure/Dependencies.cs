using EshopOnVue.js.Core.Interfaces.Repositories;
using EshopOnVue.js.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopOnVue.js.Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
            }

            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<EshopContext>(options => options.UseInMemoryDatabase("Catalog"));
            }
            else
            {
                services.AddDbContext<EshopContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("CatalogConnection")));
            }

            services.AddScoped<ICatalogItemRepository, CatalogItemsRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}
