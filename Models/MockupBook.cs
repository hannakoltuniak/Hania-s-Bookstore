namespace HaniasBookstore.Models
{
    public class MockupBook : IBook
    {
        private readonly IGenre _genre = new MockupCategory();

        public IEnumerable<Book> AllBooks => new List<Book>
        {
            new Book {Id = 0001, Title = "Six of Crows", Genre = _genre.AllGenres.ToList()[0], Description = "Six dangerous outcasts. One impossible heist. Kaz's crew is the only thing that might stand between the world and destruction--if they don't kill each other first.\r\n\r\nSix of Crows by Leigh Bardugo returns to the breathtaking world of the Grishaverse in this unforgettable tale about the opportunity--and the adventure--of a lifetime.",
            Price = 7.99f, CoverURL = "https://m.media-amazon.com/images/I/91tK5sU9oOL._SL1500_.jpg", IsBestseller = true, InStock = true},

            new Book {Id = 0002, Title = "The Ex Hex", Genre = _genre.AllGenres.ToList()[1], Description = "Nine years ago, Vivienne Jones nursed her broken heart like any young witch would: vodka, weepy music, bubble baths…and a curse on the horrible boyfriend. Sure, Vivi knows she shouldn’t use her magic this way, but with only an “orchard hayride” scented candle on hand, she isn’t worried it will cause him anything more than a bad hair day or two.\r\n\r\nThat is until Rhys Penhallow, descendent of the town’s ancestors, breaker of hearts, and annoyingly just as gorgeous as he always was, returns to Graves Glen, Georgia. What should be a quick trip to recharge the town’s ley lines and make an appearance at the annual fall festival turns disastrously wrong. With one calamity after another striking Rhys, Vivi realizes her silly little Ex Hex may not have been so harmless after all.\r\n\r\nSuddenly, Graves Glen is under attack from murderous wind-up toys, a pissed off ghost, and a talking cat with some interesting things to say. Vivi and Rhys have to ignore their off the charts chemistry to work together to save the town and find a way to break the break-up curse before it’s too late.",
            Price = 16.99f, CoverURL = "https://m.media-amazon.com/images/W/MEDIAX_792452-T2/images/I/71Oh0IR0bML._SL1500_.jpg", IsBestseller = true, InStock = false},

            new Book { Id = 0003, Title = "Emma", Genre = _genre.AllGenres.ToList()[3], Description = "Emma Woodhouse is one of Austen's most captivating and vivid characters. Beautiful, spoilt, vain and irrepressibly witty, Emma organizes the lives of the inhabitants of her sleepy little village and plays matchmaker with devastating effect.",
            Price = 12.99f, CoverURL = "https://m.media-amazon.com/images/I/41LjCFM1aXL.jpg", IsBestseller = false, InStock = true},
        };

        public IEnumerable<Book> Bestsellers
        {
            get
            {
                return AllBooks.Where(e => e.IsBestseller);
            }
        }

        public Book? GetBookById(int id) => AllBooks.FirstOrDefault(e => e.Id == id);

        public IEnumerable<Book> SearchBooks (string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
