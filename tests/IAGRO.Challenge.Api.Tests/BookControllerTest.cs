using IAGRO.Challenge.Domain.Catalog.Handlers;
using IAGRO.Challenge.Domain.Catalog.Interfaces;
using Moq;
using Xunit;

namespace IAGRO.Challenge.Api.Tests
{
    public class BookControllerTest
    {
        private readonly Mock<IBookRepository> _mockRepo;
        public BookControllerTest()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
        }

        [Fact]
        public async Task GivenAnBookRequest_ShouldReturnAtLeastOneResult()
        {
            var handler = new BookQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new BookQueryRequest(), CancellationToken.None);

            Assert.True(result.Books.Count() > 0);
        }

        [Fact]
        public async Task GivenAnBookRequest_WithOrderPriceAsc_ShouldReturnAnAscOrderedByPrice()
        {
            var handler = new BookQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new BookQueryRequest()
            {
                PriceOrder = OrderType.Asc
            }, CancellationToken.None);

            Assert.True(result.Books.First().Price == (decimal)7.31);
            Assert.True(result.Books.Last().Price == (decimal)10.1);
        }


        [Fact]
        public async Task GivenAnBookReques_WithFilterByName_ShouldReturnAnAscOrderedByPrice()
        {
            var handler = new BookQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new BookQueryRequest()
            {
                Name = "Journey"
            }, CancellationToken.None);

            Assert.True(result.Books.Count() == 1);
        }

    }
}