namespace IAGRO.Challenge.Domain.Catalog.Entities
{
    public class BookSpecification
    {
        public DateTime OriginallyPublished { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public IEnumerable<string> Illustrator { get; set; }
        public IEnumerable<string> Genres { get; set; }
    }
}