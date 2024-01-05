namespace Hania_s_Bookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Genre { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public float Price { get; set; }
        public string? CoverURL { get; set; }
        public string? ImageThumbnailURL { get; set; }
        public bool InStock { get; set; }
    }
}
