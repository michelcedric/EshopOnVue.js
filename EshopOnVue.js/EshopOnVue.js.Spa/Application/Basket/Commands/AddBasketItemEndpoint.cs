using MediatR;
using MinimalApi.Endpoint;

namespace EshopOnVue.js.Spa.Application.Basket.Commands
{

    /// <summary>
    /// Endpoint to add an item in a basket
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
            ArgumentNullException.ThrowIfNull(httpContextAccessor);
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
        /// Handler to add basket item
        /// The link to the buyer is manage with a cookie
        /// </summary>
        /// <param name="addBasketItemCommand"></param>      
        /// <returns></returns>
        public async Task<IResult> HandleAsync(AddBasketItemCommand addBasketItemCommand)
        {
            addBasketItemCommand.BuyerId = GetOrCreateBuyerId();
            await _mediator.Send(addBasketItemCommand);
            return Results.Ok();
        }

        private string GetOrCreateBuyerId()
        {
            string? buyerId = null;

            if (_httpContextAccessor.HttpContext == null) throw new NullReferenceException("The http context is not defined");

            if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                buyerId = _httpContextAccessor.HttpContext.Request.Cookies[Constants.BASKET_COOKIENAME];
            }

            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
            }

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Today.AddYears(10)
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append(Constants.BASKET_COOKIENAME, buyerId, cookieOptions);

            return buyerId;
        }
    }
}
