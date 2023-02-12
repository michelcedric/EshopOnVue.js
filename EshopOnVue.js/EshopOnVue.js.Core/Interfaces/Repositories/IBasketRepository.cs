using EshopOnVue.js.Core.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Core.Interfaces.Repositories
{
    public interface IBasketRepository : IAsyncRepository<Basket, Guid>
    {
        Task<Basket> GetBasketWithItems(string buyerId, CancellationToken cancellationToken = default);
    }
}
