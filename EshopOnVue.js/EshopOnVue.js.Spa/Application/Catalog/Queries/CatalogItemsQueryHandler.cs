using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogItemsQueryHandler : IRequestHandler<CatalogItemsQueryRequest, IEnumerable<CatalogItemDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CatalogItemDto>> Handle(CatalogItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var items = new CatalogItemDto[]
            {
                new CatalogItemDto {Id=1,Name="First",PictureUri="URL2",Price=42},
                new CatalogItemDto {Id=2,Name="Toto",PictureUri="URL",Price=43}
            };
            await Task.CompletedTask;
            return items;
        }
    }
}
