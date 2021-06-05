using EshopOnVue.js.Core.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsQueryRequest, IEnumerable<CatalogItemDto>>
    {
        private readonly ICatalogItemsRepository _catalogItemsRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogItemsRepository"></param>
        public CatalogItemsQueryHandler(ICatalogItemsRepository catalogItemsRepository)
        {
            _catalogItemsRepository = catalogItemsRepository;
        }

        /// <summary>
        /// 
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
