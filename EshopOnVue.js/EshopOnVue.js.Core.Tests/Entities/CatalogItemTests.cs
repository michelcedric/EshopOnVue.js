using EshopOnVue.js.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EshopOnVue.js.Core.Tests.Entities
{
    [TestClass]
    public class CatalogItemTests
    {
        [TestMethod]
        public void CatalogItem_CreateWithAllParametersThenSuccess()
        {
            var name = "NameTest";
            var description = "Description Test";
            var price = 42.5M;
            var pictureName = "test.png";

            var catalogItem = CatalogItem.Create(name, description, price, pictureName);

            Assert.AreNotEqual(Guid.Empty, catalogItem.Id);
            Assert.AreEqual(name, catalogItem.Name);
            Assert.AreEqual(description, catalogItem.Description);
            Assert.AreEqual(price, catalogItem.Price);
            Assert.AreEqual(pictureName, catalogItem.PictureImageName);
        }
    }
}
