namespace IAGRO.Challenge.Domain.Entities
{
    public class Book
    {
        public Book(int id, string author, string name, decimal price, BookSpecification specifications)
        {
            Id = id;
            Author = author;
            Name = name;
            Price = price;
            Specifications = specifications;
        }

        public int Id { get; internal set; }
        public string Author { get; internal set; }
        public string Name { get; internal set; }
        public decimal Price { get; internal set; }
        public BookSpecification Specifications { get; internal set; }
    }
}