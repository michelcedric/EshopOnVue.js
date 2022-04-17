using EshopOnVue.js.Core.Interfaces.Repositories;
using MediatR;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    /// <summary>
    /// Handler to respond on the CatalogItemsQueryRequest
    /// </summary>
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsQueryRequest, IEnumerable<CatalogItemDto>>
    {
        private readonly ICatalogItemRepository _catalogItemsRepository;

        /// <summary>
        /// Default contructor
        /// </summary>
        /// <param name="catalogItemsRepository"></param>
        public CatalogItemsQueryHandler(ICatalogItemRepository catalogItemsRepository)
        {
            _catalogItemsRepository = catalogItemsRepository;
        }

        /// <summary>
        /// Get specific CatalogItemDto corresponding to the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CatalogItemDto>> Handle(CatalogItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var items = await _catalogItemsRepository.ListAllAsync(cancellationToken);
            var data = items.Select(i => CatalogItemDtoConverter.Convert(i)).ToList();
            return data;
        }
    }
}
