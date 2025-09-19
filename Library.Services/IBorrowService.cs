using Library.Models;

namespace Library.Services
{
    public interface IBorrowService
    {
        public interface IBorrowService
        {
            Task<Borrow> BorrowBooksAsync(Guid readerId, Guid librarianId, IEnumerable<Guid> bookIds, DateTime dueDate);

            Task<Borrow?> ReturnBooksAsync(Guid borrowId, Guid librarianId);

            Task<IEnumerable<Borrow>> GetAllBorrowsAsync();

            Task<IEnumerable<Borrow>> GetBorrowsByReaderAsync(Guid readerId);

            Task<Borrow?> GetBorrowDetailsAsync(Guid borrowId);

            Task<Borrow?> MarkBookAsLostAsync(Guid borrowId, Guid bookId, Guid librarianId);

            Task<Fine> ApplyFineAsync(Guid borrowId, decimal amount, Guid librarianId);

            Task<bool> PayFineAsync(Guid fineId);
            Task CheckOverdueBorrowsAsync();
        }
    }
}
