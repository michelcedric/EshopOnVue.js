﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EshopOnVue.js.Spa.IntegrationTests.Controllers
{
    [TestClass]
    public class CatalogControllerTests : ControllerTestBase
    {
        [TestMethod]
        public async Task List_WhenNoFilter_ThenReturnCorrectItem()
        {
            var result = await EshopClient.Catalog_ListAsync(null, null);

            Assert.AreEqual(5, result.Count);
            var catalogItem = result.OrderBy(r=>r.Name).First();
            Assert.AreNotEqual(Guid.Empty, catalogItem.Id);
            Assert.AreEqual(19.5M, catalogItem.Price);
            Assert.AreEqual("static/products/1.png", catalogItem.PictureUri);
            Assert.AreEqual(".NET Bot Black Sweatshirt", catalogItem.Name);
        }
    }
}