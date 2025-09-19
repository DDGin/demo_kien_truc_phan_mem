using Microsoft.AspNetCore.Identity;

namespace Library.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; } = string.Empty;
        public ICollection<Borrow>? ReaderBorrows { get; set; }
        public ICollection<Borrow>? LibrarianBorrows { get; set; }
    }
}
