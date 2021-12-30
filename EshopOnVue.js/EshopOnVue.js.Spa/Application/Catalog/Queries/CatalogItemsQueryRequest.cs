using MediatR;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    public class CatalogItemsQueryRequest : BaseListRequest, IRequest<IEnumerable<CatalogItemDto>>
    {
        public CatalogItemsQueryRequest(int? pageSize, int? page) : base(pageSize, page)
        {
        }
    }
}
