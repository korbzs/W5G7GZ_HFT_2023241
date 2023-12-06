using Microsoft.EntityFrameworkCore;
using System;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public class BookStoreDbContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        public BookStoreDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("BookStore");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>()
         .HasOne(b => b.Author)
         .WithMany(a => a.Books)
         .HasForeignKey(b => b.AuthorID)
         .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Book>()
         .HasOne(b => b.Publisher)
         .WithMany(p => p.Books)
         .HasForeignKey(b => b.PublisherID)
         .OnDelete(DeleteBehavior.SetNull);

            //with hasdata, without ctor
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherID = 1, PublisherName = "Libri", Headquarters = "Budapest", FoundatitonYear = 2011 },
                new Publisher { PublisherID = 2, PublisherName = "Akadémiai Kiadó", Headquarters = "Budapest", FoundatitonYear = 1828 },
                new Publisher { PublisherID = 3, PublisherName = "Corvina Könyvkiadó", Headquarters = "Budapest", FoundatitonYear = 2011 }
                ) ;

            //with hasdata, without ctor
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, AuthorName = "George Orwell", BirthYear = 1903, Nationality = "British" },
                new Author { AuthorID = 2, AuthorName = "Aldous Huxley", BirthYear = 1894, Nationality = "British" },
                new Author { AuthorID = 3, AuthorName = "Arany János", BirthYear = 1817, Nationality = "Hungarian" },
                new Author { AuthorID = 4, AuthorName = "Gárdonyi Géza", BirthYear = 1863, Nationality = "Hungarian" },
                new Author { AuthorID = 5, AuthorName = "Edith Eva Eger", BirthYear = 1927, Nationality = "Hungarian" },
                new Author { AuthorID = 6, AuthorName = "Alpár Aladár", BirthYear = 2001, Nationality = "Hungarian" }
                );


            //with hasdata, without ctor
            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1,AuthorID = 1, PublisherID = 1, Price = 4990, Title = "1984", Genre = "Dystopic Fiction", ISBN = "9780451524935", PublicationYear = 1949 },
                new Book { BookID = 2, AuthorID = 1, PublisherID = 1, Price = 4290, Title = "1984", Genre = "Dystopic Fiction", ISBN = "9780451524935", PublicationYear = 1949 },
                new Book { BookID = 3,AuthorID = 1, PublisherID = 1, Price = 3990, Title = "Animal Farm", Genre = "Allegorical Novella", ISBN = "9780451524936", PublicationYear = 1945 },
                new Book { BookID = 4,AuthorID = 1, PublisherID = 1, Price = 5490, Title = "Homage to Catalonia", Genre = "Autobiographical", ISBN = "9780156421171", PublicationYear = 1938 },
                new Book { BookID = 5,AuthorID = 2, PublisherID = 2, Price = 2990, Title = "Brave New World", Genre = "Science Fiction", ISBN = "9780060850524", PublicationYear = 1932 },
                new Book { BookID = 6,AuthorID = 2, PublisherID = 2, Price = 3790, Title = "The Doors of Perception", Genre = "Philosophical", ISBN = "9780060850525", PublicationYear = 1954 },
                new Book { BookID = 7,AuthorID = 2, PublisherID = 2, Price = 4490, Title = "Island", Genre = "Utopian Fiction", ISBN = "9780061434493", PublicationYear = 1962 },
                new Book { BookID = 8,AuthorID = 3, PublisherID = 3, Price = 1990, Title = "Toldi", Genre = "Epic Poem", ISBN = "9789635544048", PublicationYear = 1846 },
                new Book { BookID = 9,AuthorID = 3, PublisherID = 3, Price = 2290, Title = "A walesi bárdok", Genre = "Epic Poem", ISBN = "9789635544536", PublicationYear = 1857 },
                new Book { BookID = 10,AuthorID = 3, PublisherID = 3, Price = 1790, Title = "Arany János összes költeményei", Genre = "Poetry Collection", ISBN = "9789635544505", PublicationYear = 1879 },
                new Book { BookID = 11,AuthorID = 4, PublisherID = 4, Price = 2490, Title = "Egri csillagok", Genre = "Historical Novel", ISBN = "9789639683107", PublicationYear = 1899 },
                new Book { BookID = 12,AuthorID = 4, PublisherID = 4, Price = 1990, Title = "Lámpás", Genre = "Novel", ISBN = "9789638163394", PublicationYear = 1901 },
                new Book { BookID = 13,AuthorID = 4, PublisherID = 4, Price = 2290, Title = "A láthatatlan ember", Genre = "Novel", ISBN = "9789635546073", PublicationYear = 1930 },
                new Book { BookID = 14,AuthorID = 5, PublisherID = 5, Price = 1990, Title = "The Choice: Embrace the Possible", Genre = "Biography", ISBN = "9781501130786", PublicationYear = 2017 },
                new Book { BookID = 15,AuthorID = 5, PublisherID = 5, Price = 2490, Title = "The Gift: 12 Lessons to Save Your Life", Genre = "Self.Help", ISBN = "9781984800406", PublicationYear = 2020 }
            );
        }

    }
}