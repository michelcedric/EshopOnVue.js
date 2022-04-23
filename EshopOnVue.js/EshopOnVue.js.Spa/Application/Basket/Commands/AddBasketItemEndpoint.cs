using MediatR;
using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Application.Basket.Commands
{

    /// <summary>
    /// Endpoint to get CatalogItem
    /// </summary>
    public class AddBasketItemEndpoint : IEndpoint<IResult, AddBasketItemCommand>
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="httpContextAccessor"></param>
        public AddBasketItemEndpoint(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Define routing of the endpoint
        /// </summary>
        /// <param name="app"></param>
        public void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("api/Basket", async (AddBasketItemCommand command)
                => await HandleAsync(command))
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);
        }

        /// <summary>
        /// Get all catalog items available
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IResult> HandleAsync(AddBasketItemCommand addBasketItemCommand)
        {
            //    if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            //    {
            //        _username = Request.Cookies[Constants.BASKET_COOKIENAME];
            //    }
            //    if (_username != null) return;

            //    _username = Guid.NewGuid().ToString();
            //    var cookieOptions = new CookieOptions();
            //    cookieOptions.Expires = DateTime.Today.AddYears(10);
            //    Response.Cookies.Append(Constants.BASKET_COOKIENAME, _username, cookieOptions);

            //    var result = await _mediator.Send(null);
            addBasketItemCommand.BuyerId = "toto";
            var result = _mediator.Send(addBasketItemCommand);
            return Results.Ok();
        }
    }
}
