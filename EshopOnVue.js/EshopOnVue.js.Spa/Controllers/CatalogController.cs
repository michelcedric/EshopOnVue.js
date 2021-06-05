using EshopOnVue.js.Spa.Application.Catalog.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EshopOnVue.js.Spa.Controllers
{
    /// <summary>
    /// Controller to manage the catalog of product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="mediator"></param>
        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all catalog items available
        /// </summary>  
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] CatalogItemsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
