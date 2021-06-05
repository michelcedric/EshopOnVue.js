using EshopOnVue.js.Core.Entities;
using EshopOnVue.js.Core.Interfaces.Repositories;
using System;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class CatalogItemsRepository : EfRepository<CatalogItem, Guid, EshopContext>, ICatalogItemsRepository
    {
        public CatalogItemsRepository(EshopContext dbContext) : base(dbContext)
        {
        }
    }
}
