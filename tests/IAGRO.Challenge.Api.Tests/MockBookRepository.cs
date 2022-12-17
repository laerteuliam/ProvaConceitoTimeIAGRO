using IAGRO.Challenge.Domain.Catalog.Interfaces;
using Moq;
using IAGRO.Challenge.Domain.Catalog.Entities;

namespace IAGRO.Challenge.Api.Tests
{
    public static class MockBookRepository
    {
        public static Mock<IBookRepository> GetBookRepository()
        {
            var books = new Book[]
            {
                new Book
                {
                    Id = 1,
                    Name = "Journey to the Center of the Earth",
                    Price=10
                },
                new Book
                {
                    Id = 2,
                    Name = "20,000 Leagues Under the Sea",
                    Price=(decimal)10.1
                },
                new Book
                {
                    Id = 3,
                    Name = "Harry Potter and the Goblet of Fire",
                    Price=(decimal)7.31
                }
            };

            var mockRepo = new Mock<IBookRepository>();

            mockRepo.Setup(r => r.Get()).Returns(books);

            mockRepo.Setup(r => r.GetById(It.IsAny<int>())).Returns(books[0]);

            return mockRepo;

        }
    }

}