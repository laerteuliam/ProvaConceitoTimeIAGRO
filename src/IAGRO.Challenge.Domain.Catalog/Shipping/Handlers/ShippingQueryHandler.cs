using IAGRO.Challenge.Domain.Catalog.Interfaces;
using MediatR;
namespace IAGRO.Challenge.Domain.Shipping.Handlers
{
    public class ShippingQueryHandler : IRequestHandler<ShippingQueryRequest, ShippingQueryResult>
    {
        private readonly IBookRepository bookRepository;

        public ShippingQueryHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }


        public async Task<ShippingQueryResult> Handle(ShippingQueryRequest request, CancellationToken cancellationToken)
        {
            var book = this.bookRepository.GetById(request.BookId);
            decimal shippingValue = 0;
            
            if (book!=null)
            {
                double shippingRate = 0.2;
                shippingValue = book.Price * (decimal)shippingRate;
            }

            return await Task.FromResult(new ShippingQueryResult(shippingValue));
        }
    }

    public class ShippingQueryResult
    {
        public ShippingQueryResult(decimal value)
        {
            Value = value;
        }

        public decimal Value { get; internal set; }
        
    }

    public class ShippingQueryRequest : IRequest<ShippingQueryResult>
    {
        public int BookId { get; set; }
    }
}
