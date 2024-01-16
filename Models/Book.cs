namespace HaniasBookstore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Genre Genre { get; set; } = default!;
        public string? Description { get; set; }
        public float Price { get; set; }
        public string? CoverURL { get; set; }
        public bool InStock { get; set; }
        public bool IsBestseller { get; set; }  
    }
}
