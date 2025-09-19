using Library.Models;

namespace Library.Services
{
    public interface IAuthorService
    {
        Task AddAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Guid id);
        Task<Author> GetAuthor(Guid id);
        Task<IEnumerable<Author>> GetAllAuthors();
    }
}
