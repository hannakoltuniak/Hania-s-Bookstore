namespace Hania_s_Bookstore.Models
{
    public interface IBook //using for packing all interaction data  
    {
        IEnumerable<Book> AllBooks { get; }
        IEnumerable<Book> Bestsellers { get; }
        Book? GetBookById(int id);
    }
}
