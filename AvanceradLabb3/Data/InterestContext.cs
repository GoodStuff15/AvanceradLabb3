using AvanceradLabb3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AvanceradLabb3.Data
{
    public class InterestContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();

        public DbSet<Interest> Interests => Set<Interest>();

        public InterestContext(DbContextOptions<InterestContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(

                new Person
                {
                    Id = 1,
                    FirstName = "Gustav",
                    LastName = "Eriksson",
                    Email = "vd@swedbonk.se",
                    Age = 42
                },
                new Person
                {
                    Id = 2,
                    FirstName = "McGyver",
                    LastName = "Jonsson",
                    Email = "mackans@bygghemma.se",
                    Age = 72
                },                
                new Person
                {
                    Id = 3,
                    FirstName = "Jean Claude",
                    LastName = "Van Damme",
                    Email = "jean-claude.vandamme@swipnet.se",
                    Age = 63
                }

            );

            modelBuilder.Entity<Interest>().HasData(

                new Interest
                {
                    Id = 1,
                    Title = "Magic The Gathering",
                    Description = "A collectible card game, and its rewarding and strategic gameplay, compelling characters, and fantastic Multiverse have entertained and delighted fans for more than 30 years. With more than 50 million fans to date, MAGIC is a worldwide phenomenon published in more than 150 countries."
                },
                new Interest
                {
                    Id = 2,
                    Title = "Mecka",
                    Description = "Skruva och ha sig lite"
                },
                new Interest
                {
                    Id = 3,
                    Title = "Slåss",
                    Description = "Slåss pang bom krasch!!"
                }

            );

            modelBuilder.Entity<Hyperlink>().HasData(

               new Hyperlink
               {
                   Id = 1,
                   Title = "Scryfall",
                   Url = "http://www.scryfall.com"
               },
               new Hyperlink
               {
                   Id = 2,
                   Title = "Biltema",
                   Url = "http://www.biltema.com"
               }
           );

            modelBuilder.Entity<LinkCollection>().HasData(

                new LinkCollection
                {
                    Id = 1
                },
                new LinkCollection
                {
                    Id = 2
                },
                 new LinkCollection
                 {
                     Id = 3
                 },
                 new LinkCollection
                 {
                     Id = 4
                 }
            );

            modelBuilder.Entity<Person>(p =>
            {
                p.HasMany(p => p.Interests)
                .WithMany(i => i.People)
                .UsingEntity(
                    "PersonInterest",
                    pi =>
                    {
                        //pi.HasKey("PersonId", "InterestId");
                        pi.HasData(
                            new { PeopleId = 1, InterestsId = 1, LinkCollectionId = 1 },
                            new { PeopleId = 2, InterestsId = 2, LinkCollectionId = 2 },
                            new { PeopleId = 2, InterestsId = 3, LinkCollectionId = 3 },
                            new { PeopleId = 3, InterestsId = 3, LinkCollectionId = 4 }
                        );
                    }
                );
            });


        }
    }
}
