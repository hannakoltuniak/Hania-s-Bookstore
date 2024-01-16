namespace HaniasBookstore.Models
{
    public class MockupCategory : IGenre
    {
        public IEnumerable<Genre> AllGenres => new List<Genre>
        {
            new Genre{Id = 1, Name = "Fanstasy", Description = "The fantasy genre transports readers to magical realms filled with enchanting creatures, mythical adventures, and extraordinary powers, weaving tales that defy the boundaries of reality."},
            
            new Genre{Id = 2, Name= "Romance", Description = "Romance is a genre that explores the intricate dance of love, passion, and connection, captivating readers with heartfelt narratives of relationships, desire, and the pursuit of happily-ever-afters."},
            
            new Genre{Id = 3, Name= "Thiller", Description = "Thriller is a genre that keeps readers on the edge of their seats, delivering intense suspense, unexpected twists, and gripping narratives that delve into the darker aspects of human nature and the adrenaline-fueled pursuit of resolution."},
            
            new Genre{Id = 4, Name = "Drama", Description = "Drama is a genre that delves into the complexities of human relationships and emotions, unfolding narratives that explore conflicts, triumphs, and the profound experiences of characters navigating the highs and lows of life."}
        };
    }
}
