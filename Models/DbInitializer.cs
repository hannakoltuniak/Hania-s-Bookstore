using HaniasBookstore.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace HaniasBookstore.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            Console.WriteLine("seed ziomek");
            HaniasBookstoreDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<HaniasBookstoreDbContext>();

            //var allEntities = context.Set<Book>().ToList();
            //context.RemoveRange(allEntities);

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(Genres.Select(c => c.Value));
            }

            if (!context.Books.Any())
            {
                context.AddRange
                (
                    new Book
                    {
                        Title = "Six of Crows",
                        Author = "Leigh Bardugo",
                        Genre = Genres["Fanstasy"],
                        Description = "Criminal prodigy Kaz Brekker is offered a chance at a deadly heist that could make him rich beyond his wildest dreams - but he can't pull it off alone. A convict with a thirst for revenge. A sharpshooter who can't walk away from a wager. A runaway with a privileged past. A spy known as the Wraith. A Heartrender using her magic to survive the slums. A thief with a gift for unlikely escapes. Six dangerous outcasts. One impossible heist. Kaz's crew is the only thing that might stand between the world and destruction - if they don't kill each other first.",
                        Price = 18.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/91-DipaBR2L._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "Crooked kingdom",
                        Author = "Leigh Bardugo",
                        Genre = Genres["Fanstasy"],
                        Description = "Kaz Brekker and his crew of deadly outcasts have just pulled off a heist so daring even they didn't think they'd survive. But instead of divvying up a fat reward, they're right back to fighting for their lives. Double-crossed and badly weakened, the crew is low on resources, allies, and hope. As powerful forces from around the world descend on Ketterdam to root out the secrets of the dangerous drug known as jurda parem, old rivals and new enemies emerge to challenge Kaz's cunning and test the team's fragile loyalties. A war will be waged on the city's dark and twisting streets - a battle for revenge and redemption that will decide the fate of the Grisha world.",
                        Price = 16.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/91M9xpvW7HL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "The Ex Hex",
                        Author = "Rachel Hawkins",
                        Genre = Genres["Fanstasy"],
                        Description = "Nine years ago, Vivienne Jones nursed her broken heart like any young witch would: vodka, weepy music, bubble baths…and a curse on the horrible boyfriend. Sure, Vivi knows she shouldn’t use her magic this way, but with only an “orchard hayride” scented candle on hand, she isn’t worried it will cause him anything more than a bad hair day or two.\r\n\r\nThat is until Rhys Penhallow, descendent of the town’s ancestors, breaker of hearts, and annoyingly just as gorgeous as he always was, returns to Graves Glen, Georgia. What should be a quick trip to recharge the town’s ley lines and make an appearance at the annual fall festival turns disastrously wrong. With one calamity after another striking Rhys, Vivi realizes her silly little Ex Hex may not have been so harmless after all.\r\n\r\nSuddenly, Graves Glen is under attack from murderous wind-up toys, a pissed off ghost, and a talking cat with some interesting things to say. Vivi and Rhys have to ignore their off the charts chemistry to work together to save the town and find a way to break the break-up curse before it’s too late.",
                        Price = 16.99f,
                        CoverURL = "https://m.media-amazon.com/images/W/MEDIAX_792452-T2/images/I/71Oh0IR0bML._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = false
                    },

                    new Book
                    {
                        Title = "The Lord of the Rings - Trilogy",
                        Author = "J.R.R. Tolkien",
                        Genre = Genres["Fanstasy"],
                        Description = "In a sleepy village in the Shire, young Frodo Baggins finds himself faced with an immense task, as the Ring is entrusted to his care. He must leave his home and make a perilous journey across the realms of Middle-earth to the Crack of Doom, deep inside the territories of the Dark Lord. There he must destroy the Ring forever and foil the Dark Lord in his evil purpose.",
                        Price = 24.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/41LjCFM1aXL.jpg",
                        IsBestseller = false,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "Coraline",
                        Author = "Neil Gaiman",
                        Genre = Genres["Fanstasy"],
                        Description = "When Coraline steps through a door to find another house strangely similar to her own (only better), things seem marvelous.\r\n\r\nBut there's another mother there, and another father, and they want her to stay and be their little girl. They want to change her and never let her go. Coraline will have to fight with all her wit and courage if she is to save herself and return to her ordinary life.",
                        Price = 5.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/818565mPygL._SL1500_.jpg",
                        IsBestseller = false,
                        InStock = true
                    },

                     new Book
                     {
                         Title = "The Graveyard Book",
                         Author = "Neil Gaiman",
                         Genre = Genres["Fanstasy"],
                         Description = "When a baby escapes a murderer intent on killing the entire family, who would have thought it would find safety and security in the local graveyard? Brought up by the resident ghosts, ghouls and spectres, Bod has an eccentric childhood learning about life from the dead. But for Bod there is also the danger of the murderer still looking for him - after all, he is the last remaining member of the family. A stunningly original novel deftly constructed over eight chapters, featuring every second year of Bod's life, from babyhood to adolescence. Will Bod survive to be a man?",
                         Price = 7.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/71F39D6j+4L._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "Harry Potter and the philosopher's stone",
                         Author = "J.K. Rowling",
                         Genre = Genres["Fanstasy"],
                         Description = "Harry Potter has never even heard of Hogwarts when the letters start dropping on the doormat at number four, Privet Drive. Addressed in green ink on yellowish parchment with a purple seal, they are swiftly confiscated by his grisly aunt and uncle. Then, on Harry's eleventh birthday, a great beetle-eyed giant of a man called Rubeus Hagrid bursts in with some astonishing news: Harry Potter is a wizard, and he has a place at Hogwarts School of Witchcraft and Wizardry. An incredible adventure is about to begin!",
                         Price = 9.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/81q77Q39nEL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true,
                     },

                     new Book
                     {
                         Title = "Harry Potter and the chamber of secrets",
                         Author = "J.K. Rowling",
                         Genre = Genres["Fanstasy"],
                         Description = "Harry Potter's summer has included the worst birthday ever, doomy warnings from a house-elf called Dobby, and rescue from the Dursleys by his friend Ron Weasley in a magical flying car! Back at Hogwarts School of Witchcraft and Wizardry for his second year, Harry hears strange whispers echo through empty corridors - and then the attacks start. Students are found as though turned to stone . Dobby's sinister predictions seem to be coming true. These new editions of the classic and internationally bestselling, multi-award-winning series feature instantly pick-up-able new jackets by Jonny Duddle, with huge child appeal, to bring Harry Potter to the next generation of readers. It's time to PASS THE MAGIC ON .\r\n\r\n",
                         Price = 9.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/818umIdoruL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true,
                     }
                );
            }

            context.SaveChanges();        }

        private static Dictionary<string, Genre>? genres;

        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (genres == null)
                {
                    var genresList = new Genre[]
                    {
                        new Genre { Name = "Fanstasy" },
                        new Genre { Name = "Romance" },
                        new Genre { Name = "Drama" }
                    };

                    genres = new Dictionary<string, Genre>();

                    foreach (Genre genre in genresList)
                    {
                        genres.Add(genre.Name, genre);
                    }
                }

                return genres;
            }
        }
    }
}