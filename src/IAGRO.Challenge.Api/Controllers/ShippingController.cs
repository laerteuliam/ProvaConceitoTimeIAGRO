using IAGRO.Challenge.Domain.Shipping.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAGRO.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShippingController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ShippingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ShippingQueryRequest shippingQuery)
        {
            var shippingQueryResult = await _mediator.Send(shippingQuery);
            return Ok(shippingQueryResult);
        }
    }
}