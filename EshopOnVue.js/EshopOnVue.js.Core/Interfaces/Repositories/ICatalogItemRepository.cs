using EshopOnVue.js.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Core.Interfaces.Repositories
{
    /// <summary>
    /// The repository to access on the catalog Item
    /// </summary>
    public interface ICatalogItemRepository : IAsyncRepository<CatalogItem, Guid>
    {
        /// <summary>
        /// Get the price of an existing catalog item base on id
        /// </summary>
        /// <param name="catalogItemId">The catalog item ID</param>
        /// <returns>Return null if the catalog item not exists. Otherwise return the pricing</returns>
        Task<decimal?> GetPrice(Guid catalogItemId, CancellationToken cancellationToken = default);
    }
}
