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
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] BookQuery bookQuery)
        {
            var bookQueryResult = await _mediator.Send(bookQuery);
            return (bookQueryResult.Books!=null ? Ok(bookQueryResult.Books): NotFound()) ;
        }
    }
}