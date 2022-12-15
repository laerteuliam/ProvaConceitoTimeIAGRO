namespace IAGRO.Challenge.Domain.Entities
{
    public class BookSpecification
    {
        public BookSpecification(string originallyPublished, string author, int pageCount, string[] illustrator, string[] genres)
        {
            OriginallyPublished = originallyPublished;
            Author = author;
            PageCount = pageCount;
            Illustrator = illustrator;
            Genres = genres;
        }

        public string OriginallyPublished { get; internal set; }
        public string Author { get; internal set; }
        public int PageCount { get; internal set; }
        public string[] Illustrator { get; internal set; }
        public string[] Genres { get; internal set; }
    }
}