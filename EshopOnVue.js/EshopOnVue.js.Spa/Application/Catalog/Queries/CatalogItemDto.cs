using System;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    /// <summary>
    /// Represent an element form the catalog
    /// </summary>
    public class CatalogItemDto
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Path without domain of the item's picture
        /// </summary>
        public string PictureUri { get; set; }

        /// <summary>
        /// The price
        /// </summary>
        public decimal Price { get; set; }
    }
}
