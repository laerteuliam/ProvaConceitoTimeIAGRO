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
        private readonly JsonSerializerOptions options;

        public BookRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
            
            this.options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            options.Converters.Add(new CustomDateTimeConverter("MMMM dd, yyyy"));

        }
        public Book[] Get() => JsonSerializer.Deserialize<Book[]>(dataSource.JsonData,options);
        public Book GetById(int id) => JsonSerializer.Deserialize<Book[]>(dataSource.JsonData, options).FirstOrDefault(b => b.Id == id);
        
    }
}