using MediatR;
using System.Collections.Generic;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{
    public class CatalogItemsQueryRequest : BaseListRequest, IRequest<IEnumerable<CatalogItemDto>>
    {
    }
}
