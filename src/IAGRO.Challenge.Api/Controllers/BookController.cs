using IAGRO.Challenge.Domain.Catalog.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IAGRO.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookQueryRequest bookQuery)
        {
            var bookQueryResult = await _mediator.Send(bookQuery);
            return Ok(bookQueryResult.Books);
        }
    }
}