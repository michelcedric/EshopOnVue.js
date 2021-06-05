using EshopOnVue.js.Core.Entities;
using EshopOnVue.js.Spa.Application.Catalog.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace EshopOnVue.js.Spa.Tests.Application.Catalog.Queries
{
    [TestClass]
    public class CatalogItemDtoConverterTests
    {
        [TestMethod]
        public void CatalogItemDto_WhenConvertACorrectItem_ThenSuccess()
        {
            var name = "NameTest";
            var price = 42.5M;
            var pictureName = "test.png";
            var id = Guid.NewGuid();

            var catalogItemMock = new Mock<CatalogItem>();

            catalogItemMock.Setup(s => s.Name).Returns(name);
            catalogItemMock.Setup(s => s.Price).Returns(price);
            catalogItemMock.Setup(s => s.PictureImageName).Returns(pictureName);
            catalogItemMock.Setup(s => s.Id).Returns(id);

            var dto = CatalogItemDtoConverter.Convert(catalogItemMock.Object);

            Assert.AreEqual(name, dto.Name);
            Assert.AreEqual(price, dto.Price);
            Assert.AreEqual($"static/products/{pictureName}", dto.PictureUri);
            Assert.AreEqual(id, dto.Id);
        }
    }
}
