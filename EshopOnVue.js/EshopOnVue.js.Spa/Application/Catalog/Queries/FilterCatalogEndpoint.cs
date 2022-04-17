using MediatR;
using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Application.Catalog.Queries
{

    /// <summary>
    /// Endpoint to get CatalogItem
    /// </summary>
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

        /// <summary>
        /// Define routing of the endpoint
        /// </summary>
        /// <param name="app"></param>
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapGet("api/Catalog", async (int? pageSize, int? page)
                => await HandleAsync(new CatalogItemsQueryRequest(pageSize, page)))
                .Produces<IEnumerable<CatalogItemDto>>(StatusCodes.Status200OK);
        }

        /// <summary>
        /// Get all catalog items available
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IResult> HandleAsync(CatalogItemsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Results.Ok(result);
        }
    }
}
