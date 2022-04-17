using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EshopOnVue.js.Core.Entities
{
    public class Basket : BaseEntity<Guid>
    {
        private readonly List<BasketItem> _items;

        [Required]
        public virtual string BuyerId { get; private set; }

        public virtual IReadOnlyCollection<BasketItem> Items { get => _items.ToList(); }
        public int TotalItems => Items.Sum(i => i.Quantity);

        public Basket(string buyerId)
        {
            Id = Guid.NewGuid();
            BuyerId = buyerId;
            _items = new List<BasketItem>();
        }

        public void AddItem(Guid catalogItemId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.CatalogItemId == catalogItemId))
            {
                _items.Add(new BasketItem(catalogItemId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
