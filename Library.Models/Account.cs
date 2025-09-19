/*namespace Library.Models
{
    // Không cần nữa vì đã có ApplicationUser kế thừa IdentityUser<Guid>
    public enum Role
    {
        Admin,
        Librarian,
        Reader
    }
    public class Account
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public Role Role { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
    }

}
*/