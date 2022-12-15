using IAGRO.Challenge.Domain.Entities;
using MediatR;

namespace IAGRO.Challenge.Domain.Catalog.Handlers
{
    public class BookQuery : IRequest<BookQueryResult>
    {
        public string? Author { get; set; }
        public string? Name { get; set; }
        public string? Illustrator { get; set; }
        public string? Genre { get; set; }
        public OrderType? PriceOrder { get; set; }
    }
    public class BookQueryResult
    {
        public Book[]? Books { get; set; }
    }


    public class BookQueryHandler : IRequestHandler<BookQuery, BookQueryResult>
    {
        public async Task<BookQueryResult> Handle(BookQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new BookQueryResult());
        }
    }
}
