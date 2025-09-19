namespace Library.Models
{
    public class Fine
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public Guid BorrowId { get; set; }
        public Borrow? Borrow { get; set; }
    }
}
