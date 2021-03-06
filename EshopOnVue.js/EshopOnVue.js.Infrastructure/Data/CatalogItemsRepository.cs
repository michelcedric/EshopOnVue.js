using EshopOnVue.js.Core.Entities;
using EshopOnVue.js.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class CatalogItemsRepository : EfRepository<CatalogItem, Guid, EshopContext>, ICatalogItemRepository
    {
        public CatalogItemsRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// <see cref="ICatalogItemRepository.GetPrice(Guid)"/>
        /// </summary>
        /// <param name="catalogItemId"></param>
        /// <returns></returns>
        public async Task<decimal?> GetPrice(Guid catalogItemId)
        {
            try
            {
                var price = await _dbSet.Where(c => c.Id == catalogItemId)
                    .Select(s => s.Price).FirstAsync();

                return price;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
