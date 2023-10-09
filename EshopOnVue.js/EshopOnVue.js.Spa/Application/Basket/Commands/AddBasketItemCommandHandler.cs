using EshopOnVue.js.Core.Interfaces.Repositories;
using MediatR;

namespace EshopOnVue.js.Spa.Application.Basket.Commands
{
    public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommand>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ICatalogItemRepository _catalogItemRepository;

        public AddBasketItemCommandHandler(IBasketRepository basketRepository, ICatalogItemRepository catalogItemRepository)
        {
            _basketRepository = basketRepository;
            _catalogItemRepository = catalogItemRepository;
        }

        public async Task Handle(AddBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketWithItems(request.BuyerId, cancellationToken);
            if (basket == null)
            {
                basket = new Core.Entities.Basket(request.BuyerId);
            }

            var catalogItemPrice = await _catalogItemRepository.GetPrice(request.CatalogItemId, cancellationToken);

            if (catalogItemPrice == null) throw new Exception($"Not price found for catalog item {request.CatalogItemId}");

            basket.AddItem(request.CatalogItemId, catalogItemPrice.Value, 1);

            await _basketRepository.UpdateAsync(basket, cancellationToken);          
        }
    }
}
