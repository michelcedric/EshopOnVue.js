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
                new CatalogItemDto {Id=1,Name="First",PictureUri="static/products/1.png",Price=42},
                new CatalogItemDto {Id=2,Name="Toto",PictureUri="static/products/2.png",Price=43},
                new CatalogItemDto {Id=3,Name="Chaussure",PictureUri="static/products/3.png",Price=500}
            };
            await Task.CompletedTask;
            return items;
        }
    }
}
