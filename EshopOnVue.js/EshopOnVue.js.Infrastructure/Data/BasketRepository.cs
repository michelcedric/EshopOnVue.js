using EshopOnVue.js.Core.Entities;
using EshopOnVue.js.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Infrastructure.Data
{
    public class BasketRepository : EfRepository<Basket, Guid, EshopContext>, IBasketRepository
    {
        public BasketRepository(EshopContext dbContext) : base(dbContext)
        {
        }

        public async Task<Basket> GetBasketWithItems(string buyerId, CancellationToken cancellationToken = default)
        {
            var basket = await _dbSet
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.BuyerId == buyerId, cancellationToken);

            return basket;
        }
    }
}
