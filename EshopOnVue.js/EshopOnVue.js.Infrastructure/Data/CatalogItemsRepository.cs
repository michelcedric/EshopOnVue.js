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

        public async Task<decimal> GetPrice(Guid catalogItemId)
        {
            return await _dbSet.Where(c => c.Id == catalogItemId).Select(s => s.Price).FirstOrDefaultAsync();
        }
    }
}
