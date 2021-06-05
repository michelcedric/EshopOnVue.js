using EshopOnVue.js.Core.Entities;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    public class CatalogItemDtoConverter
    {
        public static CatalogItemDto Convert(CatalogItem catalogItem)
        {
            if (catalogItem == null) return null;
            return new CatalogItemDto
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                PictureUri = $"static/products/{catalogItem.PictureImageName}",
                Price = catalogItem.Price
            };
        }
    }
}
