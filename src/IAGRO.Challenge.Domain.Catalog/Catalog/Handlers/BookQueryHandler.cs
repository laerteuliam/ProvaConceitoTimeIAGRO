using IAGRO.Challenge.Domain.Catalog.Entities;
using IAGRO.Challenge.Domain.Catalog.Interfaces;
using MediatR;

namespace IAGRO.Challenge.Domain.Catalog.Handlers
{
    public class BookQueryRequest : IRequest<BookQueryResult>
    {
        public string? Author { get; set; }
        public string? Name { get; set; }
        public string? Illustrator { get; set; }
        public string? Genre { get; set; }
        public OrderType? PriceOrder { get; set; }
    }
    public class BookQueryResult
    {
        public BookQueryResult(IEnumerable<Book> books)
        {
            Books = books;
        }

        public IEnumerable<Book> Books { get; internal set; }
    }


    public class BookQueryHandler : IRequestHandler<BookQueryRequest, BookQueryResult>
    {
        private readonly IBookRepository bookRepository;

        public BookQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<BookQueryResult> Handle(BookQueryRequest request, CancellationToken cancellationToken)
        {
            var books = bookRepository.Get();

            var filteredBooks = books.AsQueryable();

            if (request.Author != null) filteredBooks = filteredBooks.Where(b => b.Specifications.Author.Contains(request.Author)); 
            if (request.Name != null) filteredBooks = filteredBooks.Where(b => b.Name.Contains(request.Name));
            if (request.Illustrator != null) filteredBooks = filteredBooks.Where(b => b.Specifications.Illustrator.Contains(request.Illustrator));
            if (request.Genre != null) filteredBooks = filteredBooks.Where(b => b.Specifications.Genres.Contains(request.Genre));

            if (request.PriceOrder!= null) {
                if(request.PriceOrder==OrderType.Asc)
                    filteredBooks = filteredBooks.OrderBy(x => x.Price);
                if (request.PriceOrder == OrderType.Desc)
                    filteredBooks = filteredBooks.OrderByDescending(x => x.Price);
            }
            

            return await Task.FromResult(new BookQueryResult(filteredBooks));
        }
    }
}
