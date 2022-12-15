namespace IAGRO.Challenge.Domain.Catalog.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BookSpecification Specifications { get; set; }
    }
}