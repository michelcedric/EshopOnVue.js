using System;

namespace EshopOnVue.js.Core.Entities
{
    public class CatalogItem : BaseEntity<Guid>
    {
        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual decimal Price { get; private set; }
        public virtual string PictureImageName { get; private set; }

        public static CatalogItem Create(string name, string description, decimal price, string pictureImageName)
        {
            return new CatalogItem
            {
                Id = Guid.NewGuid(),
                Description = description,
                Name = name,
                PictureImageName = pictureImageName,
                Price = price
            };
        }
    }
}
