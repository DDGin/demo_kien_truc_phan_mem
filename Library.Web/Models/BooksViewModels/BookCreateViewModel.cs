namespace Library.Web.Models.BooksViewModels
{
    public class BookCreateViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int QuantityTotal { get; set; }
        public int QuantityAvailable { get; set; }
        public string Description { get; set; }
        public string ImageCover { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Guid AuthorId { get; set; }
        public string? AuthorName { get; set; }
    }
}
