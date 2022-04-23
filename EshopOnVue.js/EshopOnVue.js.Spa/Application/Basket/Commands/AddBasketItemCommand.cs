using MediatR;
using System.Text.Json.Serialization;

namespace EshopOnVue.js.Spa.Application.Basket.Commands
{
    public class AddBasketItemCommand : IRequest
    {
        [JsonIgnore]
        public string BuyerId { get; set; }

        public Guid CatalogItemId { get; init; }
    }
}
