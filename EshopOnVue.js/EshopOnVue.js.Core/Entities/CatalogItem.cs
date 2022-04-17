using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EshopOnVue.js.Core.Entities
{
    public class CatalogItem : BaseEntity<Guid>
    {
        [Required]
        public virtual string Name { get; private set; }

        [Required]
        public virtual string Description { get; private set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal Price { get; private set; }

        [Required]
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
