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
        private readonly ILogger<ShippingController> _logger;

        public ShippingController(ILogger<ShippingController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ShippingQuery shippingQuery)
        {
            var shippingQueryResult = await _mediator.Send(shippingQuery);
            return Ok(shippingQueryResult);
        }
    }
}