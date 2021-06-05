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
            services.AddDbContext<EshopContext>(options => options.UseInMemoryDatabase("Catalog"));

            services.AddScoped<ICatalogItemsRepository, CatalogItemsRepository>();
        }
    }
}
