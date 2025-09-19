using Library.Models;

namespace Library.Services
{
    public interface IBookService
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Guid id);
        Task<Book> GetBook(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}
