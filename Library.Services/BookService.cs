using Library.Models;
using Library.Repositories.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddBook(Book book)
        {
            await _unitOfWork.GenericRepository<Book>().AddAsync(book);
            _unitOfWork.Save();
        }

        public async Task DeleteBook(Guid id)
        {
            var book = await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.Id == id);
            _unitOfWork.GenericRepository<Book>().Delete(book);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _unitOfWork.GenericRepository<Book>().
                GetAll(include: x => x.
                Include(y => y.Category).
                Include(y => y.Author));
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.Id == id);
        }

        public async Task UpdateBook(Book book)
        {
            var BookFromDb = await _unitOfWork.GenericRepository<Book>().GetByIdAsync(filter: x => x.Id == book.Id);
            if (BookFromDb != null)
            {
                BookFromDb.Title = book.Title;
                BookFromDb.ISBN = book.ISBN;
                BookFromDb.PublicationDate = DateTime.UtcNow;
                BookFromDb.QuantityTotal = book.QuantityTotal;
                BookFromDb.QuantityAvailable = book.QuantityAvailable;
                BookFromDb.Description = book.Description;
                BookFromDb.ImageCover = book.ImageCover;
                BookFromDb.CategoryId = book.CategoryId;
                BookFromDb.AuthorId = book.AuthorId;

                _unitOfWork.GenericRepository<Book>().Update(BookFromDb);
                _unitOfWork.Save();
            }

        }
    }
}
