using Ardalis.GuardClauses;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnVue.js.Core.Entities
{
    public class BasketItem : BaseEntity<Guid>
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public Guid CatalogItemId { get; private set; }
        public Guid BasketId { get; private set; }

        public BasketItem(Guid catalogItemId, int quantity, decimal unitPrice)
        {
            Id = Guid.NewGuid();
            CatalogItemId = catalogItemId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);
            Quantity = quantity;
        }
    }
}