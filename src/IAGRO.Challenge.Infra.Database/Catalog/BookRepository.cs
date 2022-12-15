using IAGRO.Challenge.Database.Core;
using IAGRO.Challenge.Domain.Catalog.Entities;
using IAGRO.Challenge.Domain.Catalog.Interfaces;
using IAGRO.Challenge.Domain.Core.Interfaces;
using System.Text.Json;

namespace IAGRO.Challenge.Database.Catalog
{
    public class BookRepository : IBookRepository
    {
        private readonly IDataSource dataSource;

        public BookRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Book[] Get() {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            options.Converters.Add(new CustomDateTimeConverter("MMMM dd, yyyy"));

            var books = JsonSerializer.Deserialize<Book[]>(dataSource.JsonData,options);

            return books;
        }
    }
}