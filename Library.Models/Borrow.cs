namespace Library.Models
{
    public enum Status
    {
        Returned,
        Overdue,
        Borrowed,
        Lost
    }
    public class Borrow
    {
        public Guid Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DueDate { get; set; }
        public Status Status { get; set; }
        public Fine? Fine { get; set; }
        public Guid ReaderId { get; set; }
        public ApplicationUser? Reader { get; set; }
        public Guid LibrarianId { get; set; }
        public ApplicationUser? Librarian { get; set; }

        public ICollection<Book>? Books { get; set; }

        public bool IsOverDue =>
            DueDate.HasValue && DateTime.Now > DueDate.Value && Status == Status.Borrowed;

        public bool IsMarkedReturn =>
            Status == Status.Returned || ReturnDate.HasValue;
    }
}
