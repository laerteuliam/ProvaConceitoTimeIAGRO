using IAGRO.Challenge.Domain.Catalog.Interfaces;
using IAGRO.Challenge.Domain.Shipping.Handlers;
using Moq;
using Xunit;

namespace IAGRO.Challenge.Api.Tests
{
    public class ShippingControllerTest
    {
        private readonly Mock<IBookRepository> _mockRepo;
        public ShippingControllerTest()
        {
            _mockRepo = MockBookRepository.GetBookRepository();
        }

        [Fact]
        public async Task GivenAnShippingRequest_ShouldReturnACorrectShippingValue()
        {
            var handler = new ShippingQueryHandler(_mockRepo.Object);

            var result = await handler.Handle(new ShippingQueryRequest()
            {
                BookId = 1
            }, CancellationToken.None);

            Assert.True(result.Value == (decimal)2);
        }

    }
}