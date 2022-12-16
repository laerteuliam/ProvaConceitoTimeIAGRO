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

        public Book[] Get() => dataSource.JsonToObject<Book[]>();
        public Book GetById(int id) => dataSource.JsonToObject<Book[]>().FirstOrDefault(b => b.Id == id);
        
    }
}