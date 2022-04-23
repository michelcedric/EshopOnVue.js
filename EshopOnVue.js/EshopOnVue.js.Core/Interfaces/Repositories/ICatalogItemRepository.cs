using EshopOnVue.js.Core.Entities;
using System;
using System.Threading.Tasks;

namespace EshopOnVue.js.Core.Interfaces.Repositories
{
    public interface ICatalogItemRepository : IAsyncRepository<CatalogItem, Guid>
    {
        Task<decimal> GetPrice(Guid catalogItemId);
    }
}
