using IAGRO.Challenge.Domain.Catalog.Entities;

namespace IAGRO.Challenge.Domain.Catalog.Interfaces
{
    public interface IBookRepository
    {
        Book GetById(int id);
        Book[] Get();
    }
}
