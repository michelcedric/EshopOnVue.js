using EshopOnVue.js.Core.Entities;
using System;

namespace EshopOnVue.js.Core.Interfaces.Repositories
{
    public interface ICatalogItemRepository : IAsyncRepository<CatalogItem, Guid>
    {
    }
}
