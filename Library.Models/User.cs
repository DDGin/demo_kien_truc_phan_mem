/*namespace Library.Models
{
    // Không cần nữa vì đã có ApplicationUser kế thừa IdentityUser<Guid>
    public class User
    {
        public Guid Id { get; set; }
        public required string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        public Guid AccountId { get; set; }
        public Account? Account { get; set; }
        public ICollection<Borrow>? Borrows { get; set; }
    }
}
*/