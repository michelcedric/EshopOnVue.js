using EshopOnVue.js.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EshopOnVue.js.Core.Tests.Entities
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void Basket_CreateWithAllParametersThenSuccess()
        {
            string buyerId = "Toto";

            var basket = new Basket(buyerId);

            Assert.AreEqual(buyerId, basket.BuyerId);
            Assert.AreEqual(0,basket.TotalItems);
            Assert.AreNotEqual(Guid.Empty, basket.Id);
        }

        [TestMethod]
        public void Basket_AddItemThenCorrectlyAdded()
        {
            var buyerId = "Toto";
            var catalogItemId = Guid.NewGuid();
            var price = 42.32M;
            var quantity = 42;

            var basket = new Basket(buyerId);
            basket.AddItem(catalogItemId, price, quantity);

            Assert.AreEqual(42, basket.Items.First().Quantity);
            Assert.AreEqual(price, basket.Items.First().UnitPrice);
            Assert.AreEqual(catalogItemId, basket.Items.First().CatalogItemId);
            Assert.AreNotEqual(Guid.Empty, basket.Items.First().Id);

        }
    }
}
