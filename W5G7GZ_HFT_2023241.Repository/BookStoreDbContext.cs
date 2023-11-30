using Microsoft.EntityFrameworkCore;
using System;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public class BookStoreDbContext : DbContext // used Microsoft.EntityFrameworkCore 5.0.11
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
                //string conn =
                //  @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =|DataDirectory|\Database.mdf; Integrated Security = True; MultipleActiveResultSets=true";
                builder
                    .UseLazyLoadingProxies()
                    //.UseSqlServer(conn)
                    .UseInMemoryDatabase("BookStore");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>()
            //.HasKey(b => b.BookID);

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

        //modelBuilder.Entity<Book>()
        //            .Property(b => b.BookID)
        //            .ValueGeneratedOnAdd(); // start 1, incr 1

        //modelBuilder.Entity<Author>()
        //            .Property(a => a.AuthorID)
        //            .ValueGeneratedOnAdd();
        //             // start 1, incr 1

        //modelBuilder.Entity<Publisher>()
        //            .Property(p => p.PublisherID)
        //             .ValueGeneratedOnAdd(); // start 1, incr 1

            //publisher with ID
            //Publisher libri = new Publisher(1, "Libri", "Budapest", 2011);
            //Publisher akademiai = new Publisher(2, "Akadémiai Kiadó", "Budapest", 1828);
            //Publisher corvina = new Publisher(3, "Corvina Könyvkiadó", "Budapest", 2011);

            //publisher without ID
            //Publisher libri = new Publisher("Libri", "Budapest", 2011);
            //Publisher akademiai = new Publisher("Akadémiai Kiadó", "Budapest", 1828);
            //Publisher corvina = new Publisher("Corvina Könyvkiadó", "Budapest", 2011);
            //modelBuilder.Entity<Publisher>().HasData(libri, akademiai, corvina);

            //publisher with hasdata, without ctor
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherID = 1, PublisherName = "Libri", Headquarters = "Budapest", FoundatitonYear = 2011 },
                new Publisher { PublisherID = 2, PublisherName = "Akadémiai Kiadó", Headquarters = "Budapest", FoundatitonYear = 1828 },
                new Publisher { PublisherID = 3, PublisherName = "Corvina Könyvkiadó", Headquarters = "Budapest", FoundatitonYear = 2011 }
                ) ;


            //author with ID
            //Author author1 = new Author(1, "George Orwell", 1903, "British"); //id start 1
            //Author author2 = new Author(2, "Aldous Huxley", 1894, "British");
            //Author author3 = new Author(3, "Arany János", 1817, "Hungarian");
            //Author author4 = new Author(4, "Gárdonyi Géza", 1863, "Hungarian");
            //Author author5 = new Author(5, "Edith Eva Eger", 1927, "Hungarian");
            //Author author6 = new Author(5, "Alpár Aladár", 2001, "Hungarian");

            //author without ID
            //Author author1 = new Author("George Orwell", 1903, "British"); //id start 1
            //Author author2 = new Author("Aldous Huxley", 1894, "British");
            //Author author3 = new Author("Arany János", 1817, "Hungarian");
            //Author author4 = new Author("Gárdonyi Géza", 1863, "Hungarian");
            //Author author5 = new Author("Edith Eva Eger", 1927, "Hungarian");
            //Author author6 = new Author("Alpár Aladár", 2001, "Hungarian");
            //modelBuilder.Entity<Author>().HasData(author1, author2, author3, author4, author5);

            //with hasdata, without ctor
            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorID = 1, AuthorName = "George Orwell", BirthYear = 1903, Nationality = "British" },
                new Author { AuthorID = 2, AuthorName = "Aldous Huxley", BirthYear = 1894, Nationality = "British" },
                new Author { AuthorID = 3, AuthorName = "Arany János", BirthYear = 1817, Nationality = "Hungarian" },
                new Author { AuthorID = 4, AuthorName = "Gárdonyi Géza", BirthYear = 1863, Nationality = "Hungarian" },
                new Author { AuthorID = 5, AuthorName = "Edith Eva Eger", BirthYear = 1927, Nationality = "Hungarian" },
                new Author { AuthorID = 6, AuthorName = "Alpár Aladár", BirthYear = 2001, Nationality = "Hungarian" }
                );


            //book with id in ctor
            //Book book1 = new Book(1, 1, 1, 4990, "1984", "Dystopic Fiction", "9780451524935", 1949);
            //Book book1_ = new Book(2, 1, 1, 4290, "1984", "Dystopic Fiction", "9780451524935", 1949);
            //Book book2 = new Book(3, 1, 2, 3990, "Animal Farm", "Allegorical Novella", "9780451524936", 1945);
            //Book book3 = new Book(4, 1, 2, 5490, "Homage to Catalonia", "Autobiographical", "9780156421171", 1938);
            //Book book4 = new Book(5, 2, 2, 2990, "Brave New World", "Science Fiction", "9780060850524", 1932);
            //Book book5 = new Book(6, 2, 2, 3790, "The Doors of Perception", "Philosophical", "9780060850525", 1954);
            //Book book6 = new Book(7, 2, 2, 4490, "Island", "Utopian Fiction", "9780061434493", 1962);
            //Book book7 = new Book(8, 3, 3, 1990, "Toldi", "Epic Poem", "9789635544048", 1846);
            //Book book8 = new Book(9, 3, 3, 2290, "A walesi bárdok", "Epic Poem", "9789635544536", 1857);
            //Book book9 = new Book(10, 3, 3, 1790, "Arany János összes költeményei", "Poetry Collection", "9789635544505", 1879);
            //Book book10 = new Book(11, 4, 4, 2490, "Egri csillagok", "Historical Novel", "9789639683107", 1899);
            //Book book11 = new Book(12, 4, 4, 1990, "Lámpás", "Novel", "9789638163394", 1901);
            //Book book12 = new Book(13, 4, 4, 2290, "A láthatatlan ember", "Novel", "9789635546073", 1930);
            //Book book13 = new Book(14, 5, 5, 1990, "The Choice: Embrace the Possible", "Biography", "9781501130786", 2017);
            //Book book14 = new Book(15, 5, 5, 2490, "The Gift: 12 Lessons to Save Your Life", "Self.Help", "9781984800406", 2020);

            //book without id in ctor
            //Book book1 = new Book(1, 1, 4990, "1984", "Dystopic Fiction", "9780451524935", 1949);
            //Book book1_ = new Book(1, 1, 4290, "1984", "Dystopic Fiction", "9780451524935", 1949);
            //Book book2 = new Book(1, 2, 3990, "Animal Farm", "Allegorical Novella", "9780451524936", 1945);
            //Book book3 = new Book(1, 2, 5490, "Homage to Catalonia", "Autobiographical", "9780156421171", 1938);
            //Book book4 = new Book(2, 2, 2990, "Brave New World", "Science Fiction", "9780060850524", 1932);
            //Book book5 = new Book(2, 2, 3790, "The Doors of Perception", "Philosophical", "9780060850525", 1954);
            //Book book6 = new Book(2, 2, 4490, "Island", "Utopian Fiction", "9780061434493", 1962);
            //Book book7 = new Book(3, 3, 1990, "Toldi", "Epic Poem", "9789635544048", 1846);
            //Book book8 = new Book(3, 3, 2290, "A walesi bárdok", "Epic Poem", "9789635544536", 1857);
            //Book book9 = new Book(3, 3, 1790, "Arany János összes költeményei", "Poetry Collection", "9789635544505", 1879);
            //Book book10 = new Book(4, 4, 2490, "Egri csillagok", "Historical Novel", "9789639683107", 1899);
            //Book book11 = new Book(4, 4, 1990, "Lámpás", "Novel", "9789638163394", 1901);
            //Book book12 = new Book(4, 4, 2290, "A láthatatlan ember", "Novel", "9789635546073", 1930);
            //Book book13 = new Book(5, 5, 1990, "The Choice: Embrace the Possible", "Biography", "9781501130786", 2017);
            //Book book14 = new Book(5, 5, 2490, "The Gift: 12 Lessons to Save Your Life", "Self.Help", "9781984800406", 2020);
            //modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14);

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