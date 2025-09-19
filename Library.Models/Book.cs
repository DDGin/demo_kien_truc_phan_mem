namespace Library.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int QuantityTotal { get; set; }
        public int QuantityAvailable { get; set; }
        public required string Description { get; set; }
        public required string ImageCover { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
        public ICollection<Borrow>? Borrows { get; set; }

    }
}
