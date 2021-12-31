using EshopOnVue.js.Spa.Application.Catalog.Queries;
using MediatR;
using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Controllers
{

    public class FilterCatalogEndpoint : IEndpoint<IResult, CatalogItemsQueryRequest>
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        public FilterCatalogEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/Catalog", async (int? pageSize, int? page)
                => await Handle(new CatalogItemsQueryRequest(pageSize, page)))
                .Produces<IEnumerable<CatalogItemDto>>(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Get all catalog items available
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IResult> Handle(CatalogItemsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Results.Ok(result);
        }
    }
}
