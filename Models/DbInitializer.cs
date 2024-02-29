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
                    //FANTASY
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
                        CoverURL = "https://m.media-amazon.com/images/I/71Oh0IR0bML._SL1500_.jpg",
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
                        CoverURL = "https://m.media-amazon.com/images/I/81nV6x2ey4L._SL1500_.jpg",
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
                     },

                     //ROMANCE
                     new Book
                     {
                         Title = "The Hating Game",
                         Author = "Sally Thorne",
                         Genre = Genres["Romance"],
                         Description = "Lucy Hutton and Joshua Templeman hate each other. Not dislike. Not begrudgingly tolerate. Hate. And they have no problem displaying their feelings through a series of ritualistic passive aggressive maneuvers as they sit across from each other, executive assistants to co-CEOs of a publishing company. Lucy can’t understand Joshua’s joyless, uptight, meticulous approach to his job. Joshua is clearly baffled by Lucy’s overly bright clothes, quirkiness, and Pollyanna attitude.\r\n\r\nNow up for the same promotion, their battle of wills has come to a head and Lucy refuses to back down when their latest game could cost her her dream job…But the tension between Lucy and Joshua has also reached its boiling point, and Lucy is discovering that maybe she doesn’t hate Joshua. And maybe, he doesn’t hate her either. Or maybe this is just another game.",
                         Price = 11.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/717uYVw9SSL._SL1500_.jpg",
                         IsBestseller = true,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "Me Before You",
                         Author = "Jojo Moyes",
                         Genre = Genres["Romance"],
                         Description = "They had nothing in common until love gave them everything to lose . . .\r\n\r\nLouisa Clark is an ordinary girl living an exceedingly ordinary life—steady boyfriend, close family—who has barely been farther afield than their tiny village. She takes a badly needed job working for ex–Master of the Universe Will Traynor, who is wheelchair bound after an accident. Will has always lived a huge life—big deals, extreme sports, worldwide travel—and now he’s pretty sure he cannot live the way he is.\r\n\r\nWill is acerbic, moody, bossy—but Lou refuses to treat him with kid gloves, and soon his happiness means more to her than she expected. When she learns that Will has shocking plans of his own, she sets out to show him that life is still worth living",
                         Price = 12.49f,
                         CoverURL = "https://m.media-amazon.com/images/I/71Rf0Ol-fPL._SL1500_.jpg",
                         IsBestseller = true,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "The Kiss Quotient",
                         Author = "Helen Hoang",
                         Genre = Genres["Romance"],
                         Description = "The Kiss Quotient is a contemporary romance novel that follows the relationship between Stella Lane, an autistic woman with a love for mathematics, and Michael Phan, an escort she hires to teach her about intimacy.",
                         Price = 9.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/81f8yUOWDmL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "Red, White & Royal Blue",
                         Author = "Casey McQuiston",
                         Genre = Genres["Romance"],
                         Description = "What happens when America's First Son falls in love with the Prince of Wales?\r\n\r\nWhen his mother became President, Alex Claremont-Diaz was promptly cast as the American equivalent of a young royal. Handsome, charismatic, genius―his image is pure millennial-marketing gold for the White House. There's only one problem: Alex has a beef with the actual prince, Henry, across the pond. And when the tabloids get hold of a photo involving an Alex-Henry altercation, U.S./British relations take a turn for the worse.\r\n\r\nHeads of family, state, and other handlers devise a plan for damage control: staging a truce between the two rivals. What at first begins as a fake, Instragramable friendship grows deeper, and more dangerous, than either Alex or Henry could have imagined. Soon Alex finds himself hurtling into a secret romance with a surprisingly unstuffy Henry that could derail the campaign and upend two nations and begs the question: Can love save the world after all? Where do we find the courage, and the power, to be the people we are meant to be? And how can we learn to let our true colors shine through? Casey McQuiston's Red, White & Royal Blue proves: true love isn't always diplomatic.",
                         Price = 8.79f,
                         CoverURL = "https://m.media-amazon.com/images/I/71skR7IaVEL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "The Flatshare",
                         Author = "Beth O'Leary",
                         Genre = Genres["Romance"],
                         Description = "Tiffy and Leon share an apartment. Tiffy and Leon have never met.\r\n\r\nAfter a bad breakup, Tiffy Moore needs a place to live. Fast. And cheap. But the apartments in her budget have her wondering if astonishingly colored mold on the walls counts as art.\r\n\r\nDesperation makes her open minded, so she answers an ad for a flatshare. Leon, a night shift worker, will take the apartment during the day, and Tiffy can have it nights and weekends. He’ll only ever be there when she’s at the office. In fact, they’ll never even have to meet.\r\n\r\nTiffy and Leon start writing each other notes – first about what day is garbage day, and politely establishing what leftovers are up for grabs, and the evergreen question of whether the toilet seat should stay up or down. Even though they are opposites, they soon become friends. And then maybe more.\r\n\r\nBut falling in love with your roommate is probably a terrible idea…especially if you've never met.",
                         Price = 7.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/812JWi-SjHL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "One Day",
                         Author = "David Nicholls",
                         Genre = Genres["Romance"],
                         Description = "t’s 1988 and Dexter Mayhew and Emma Morley have only just met. But after only one day together, they cannot stop thinking about one another. Over twenty years, snapshots of that relationship are revealed on the same day—July 15th—of each year. They face squabbles and fights, hopes and missed opportunities, laughter and tears. Dex and Em must come to grips with the nature of love and life itself. As the years go by,  the true meaning of this one crucial day is revealed. ",
                         Price = 11.49f,
                         CoverURL = "https://m.media-amazon.com/images/I/71wn8mzLXdL._SL1500_.jpg",
                         IsBestseller = true,
                         InStock = true
                     },


                     new Book
                     {
                         Title = "Eleanor Oliphant Is Completely Fine",
                         Author = "Gail Honeyman",
                         Genre = Genres["Romance"],
                         Description = "Meet Eleanor Oliphant: She struggles with appropriate social skills and tends to say exactly what she’s thinking. Nothing is missing in her carefully timetabled life of avoiding social interactions, where weekends are punctuated by frozen pizza, vodka, and phone chats with Mummy. \r\n\r\nBut everything changes when Eleanor meets Raymond, the bumbling and deeply unhygienic IT guy from her office. When she and Raymond together save Sammy, an elderly gentleman who has fallen on the sidewalk, the three become the kinds of friends who rescue one another from the lives of isolation they have each been living. And it is Raymond’s big heart that will ultimately help Eleanor find the way to repair her own profoundly damaged one.\r\n\r\nSoon to be a major motion picture produced by Reese Witherspoon, Eleanor Oliphant Is Completely Fine is the smart, warm, and uplifting story of an out-of-the-ordinary heroine whose deadpan weirdness and unconscious wit make for an irresistible journey as she realizes. . .",
                         Price = 9.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/81NamvANplL._SL1500_.jpg",
                         IsBestseller = false,
                         InStock = true
                     },

                     new Book
                     {
                         Title = "The Rosie Project",
                         Author = "Graeme Simsion",
                         Genre = Genres["Romance"],
                         Description = "The art of love is never a science: Meet Don Tillman, a brilliant yet socially inept professor of genetics, who’s decided it’s time he found a wife. In the orderly, evidence-based manner with which Don approaches all things, he designs the Wife Project to find his perfect partner: a sixteen-page, scientifically valid survey to filter out the drinkers, the smokers, the late arrivers.\r\n\r\nRosie Jarman possesses all these qualities. Don easily disqualifies her as a candidate for The Wife Project (even if she is “quite intelligent for a barmaid”). But Don is intrigued by Rosie’s own quest to identify her biological father. When an unlikely relationship develops as they collaborate on The Father Project, Don is forced to confront the spontaneous whirlwind that is Rosie―and the realization that, despite your best scientific efforts, you don’t find love, it finds you.",
                         Price = 10.99f,
                         CoverURL = "https://m.media-amazon.com/images/I/71zbZ+vTjQL._SL1500_.jpg",
                         IsBestseller = true,
                         InStock = true
                     },

                    //DRAMA
                    new Book
                    {
                        Title = "The Nightingale",
                        Author = "Kristin Hannah",
                        Genre = Genres["Drama"],
                        Description = "France, 1939 - In the quiet village of Carriveau, Vianne Mauriac says goodbye to her husband, Antoine, as he heads for the Front. She doesn't believe that the Nazis will invade France … but invade they do, in droves of marching soldiers, in caravans of trucks and tanks, in planes that fill the skies and drop bombs upon the innocent. When a German captain requisitions Vianne's home, she and her daughter must live with the enemy or lose everything. Without food or money or hope, as danger escalates all around them, she is forced to make one impossible choice after another to keep her family alive.\r\n\r\nVianne's sister, Isabelle, is a rebellious eighteen-year-old girl, searching for purpose with all the reckless passion of youth. While thousands of Parisians march into the unknown terrors of war, she meets Gäetan, a partisan who believes the French can fight the Nazis from within France, and she falls in love as only the young can … completely. But when he betrays her, Isabelle joins the Resistance and never looks back, risking her life time and again to save others.\r\n\r\nWith courage, grace, and powerful insight, bestselling author Kristin Hannah captures the epic panorama of World War II and illuminates an intimate part of history seldom seen: the women's war. The Nightingale tells the stories of two sisters, separated by years and experience, by ideals, passion and circumstance, each embarking on her own dangerous path toward survival, love, and freedom in German-occupied, war-torn France―a heartbreakingly beautiful novel that celebrates the resilience of the human spirit and the durability of women. It is a novel for everyone, a novel for a lifetime.\r\n\r\nGoodreads Best Historical Novel of the Year • People's Choice Favorite Fiction Winner • #1 Indie Next Sele",
                        Price = 9.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/81OkWjcf4WL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "A Little Life",
                        Author = "Hanya Yanagihara",
                        Genre = Genres["Drama"],
                        Description = "A Little Life follows four college classmates—broke, adrift, and buoyed only by their friendship and ambition—as they move to New York in search of fame and fortune. While their relationships, which are tinged by addiction, success, and pride, deepen over the decades, the men are held together by their devotion to the brilliant, enigmatic Jude, a man scarred by an unspeakable childhood trauma. A hymn to brotherly bonds and a masterful depiction of love in the twenty-first century, Hanya Yanagihara’s stunning novel is about the families we are born into, and those that we make for ourselves.",
                        Price = 14.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/91fRT+cJNzL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "The Kite Runner",
                        Author = "Khaled Hosseini",
                        Genre = Genres["Drama"],
                        Description = "The unforgettable, heartbreaking story of the unlikely friendship between a wealthy boy and the son of his father’s servant, caught in the tragic sweep of history, The Kite Runner transports readers to Afghanistan at a tense and crucial moment of change and destruction. A powerful story of friendship, it is also about the power of reading, the price of betrayal, and the possibility of redemption; and an exploration of the power of fathers over sons—their love, their sacrifices, their lies.\r\n",
                        Price = 10.49f,
                        CoverURL = "https://m.media-amazon.com/images/I/81LVEH25iJL._SL1500_.jpg",
                        IsBestseller = false,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "All the Light We Cannot See",
                        Author = "Anthony Doerr",
                        Genre = Genres["Drama"],
                        Description = "Marie-Laure lives with her father in Paris near the Museum of Natural History where he works as the master of its thousands of locks. When she is six, Marie-Laure goes blind and her father builds a perfect miniature of their neighborhood so she can memorize it by touch and navigate her way home. When she is twelve, the Nazis occupy Paris, and father and daughter flee to the walled citadel of Saint-Malo, where Marie-Laure’s reclusive great uncle lives in a tall house by the sea. With them they carry what might be the museum’s most valuable and dangerous jewel.\r\n",
                        Price = 12.79f,
                        CoverURL = "https://m.media-amazon.com/images/I/81RBTG28sCL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "The Goldfinch",
                        Author = "Donna Tartt",
                        Genre = Genres["Drama"],
                        Description = "Theo Decker, a 13-year-old New Yorker, miraculously survives an accident that kills his mother. Abandoned by his father, Theo is taken in by the family of a wealthy friend. Bewildered by his strange new home on Park Avenue, disturbed by schoolmates who don't know how to talk to him, and tormented above all by a longing for his mother, he clings to the one thing that reminds him of her: a small, mysteriously captivating painting that ultimately draws Theo into a wealthy and insular art community.\r\n\r\nAs an adult, Theo moves silkily between the drawing rooms of the rich and the dusty labyrinth of an antiques store where he works. He is alienated and in love — and at the center of a narrowing, ever more dangerous circle.",
                        Price = 16.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/81QxwwBNU9L._SL1500_.jpg",
                        IsBestseller = false,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "The Great Alone",
                        Author = "Kristin Hannah",
                        Genre = Genres["Drama"],
                        Description = "Alaska, 1974. Ernt Allbright came home from the Vietnam War a changed and volatile man. When he loses yet another job, he makes the impulsive decision to move his wife and daughter north where they will live off the grid in America’s last true frontier.\r\n\r\nCora will do anything for the man she loves, even if means following him into the unknown. Thirteen-year-old Leni, caught in the riptide of her parents’ passionate, stormy relationship, has little choice but to go along, daring to hope this new land promises her family a better future.\r\n\r\nIn a wild, remote corner of Alaska, the Allbrights find a fiercely independent community of strong men and even stronger women. The long, sunlit days and the generosity of the locals make up for the newcomers’ lack of preparation and dwindling resources.\r\n\r\nBut as winter approaches and darkness descends, Ernt’s fragile mental state deteriorates. Soon the perils outside pale in comparison to threats from within. In their small cabin, covered in snow, blanketed in eighteen hours of night, Leni and her mother learn the terrible truth: they are on their own.",
                        Price = 9.49f,
                        CoverURL = "https://m.media-amazon.com/images/I/81DCCd9KYSL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "Educated",
                        Author = "Tara Westover",
                        Genre = Genres["Drama"],
                        Description = "Born to survivalists in the mountains of Idaho, Tara Westover was seventeen the first time she set foot in a classroom. Her family was so isolated from mainstream society that there was no one to ensure the children received an education, and no one to intervene when one of Tara’s older brothers became violent. When another brother got himself into college, Tara decided to try a new kind of life. Her quest for knowledge transformed her, taking her over oceans and across continents, to Harvard and to Cambridge University. Only then would she wonder if she’d traveled too far, if there was still a way home.\r\n",
                        Price = 10.99f,
                        CoverURL = "https://m.media-amazon.com/images/I/81Om0n+pfyL._SL1500_.jpg",
                        IsBestseller = false,
                        InStock = true
                    },

                    new Book
                    {
                        Title = "Where the Crawdads Sing",
                        Author = "Delia Owens",
                        Genre = Genres["Drama"],
                        Description = "For years, rumors of the “Marsh Girl” have haunted Barkley Cove, a quiet town on the North Carolina coast. So in late 1969, when handsome Chase Andrews is found dead, the locals immediately suspect Kya Clark, the so-called Marsh Girl. But Kya is not what they say. Sensitive and intelligent, she has survived for years alone in the marsh that she calls home, finding friends in the gulls and lessons in the sand. Then the time comes when she yearns to be touched and loved. When two young men from town become intrigued by her wild beauty, Kya opens herself to a new life—until the unthinkable happens.\r\n",
                        Price = 10.49f,
                        CoverURL = "https://m.media-amazon.com/images/I/81O1oy0y9eL._SL1500_.jpg",
                        IsBestseller = true,
                        InStock = true
                    }
                );

                context.SaveChanges();
            }
        }

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