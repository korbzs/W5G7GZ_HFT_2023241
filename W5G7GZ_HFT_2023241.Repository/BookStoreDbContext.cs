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

            Publisher libri = new Publisher(1, "Libri", "Budapest", 2011);
            Publisher akademiai = new Publisher(2, "Akadémiai Kiadó", "Budapest", 1828);
            Publisher corvina = new Publisher(3, "Corvina Könyvkiadó", "Budapest", 2011);

            Author author1 = new Author(1, "George Orwell", DateTime.Parse("1903.06.25"), "British");
            Author author2 = new Author(2, "Aldous Huxley", DateTime.Parse("1894.06.26"), "British");
            Author author3 = new Author(3, "Arany János", DateTime.Parse("1817.03.02"), "Hungarian");
            Author author4 = new Author(4, "Gárdonyi Géza", DateTime.Parse("1863.08.03"), "Hungarian");
            Author author5 = new Author(5, "Edith Eva Eger", DateTime.Parse("1927.09.29"), "Hungarian");
            Author author6 = new Author(5, "Alpár Aladár", DateTime.Parse("2001.01.01"), "Hungarian");


            Book book1 = new Book(1, 1, 4990, "1984", "Dystopic Fiction", "9780451524935", DateTime.Parse("1949.06.08"));
            Book book1_ = new Book(1, 2, 4290, "1984", "Dystopic Fiction", "9780451524935", DateTime.Parse("1949.06.08"));
            Book book2 = new Book(1, 3, 3990, "Animal Farm", "Allegorical Novella", "9780451524936", DateTime.Parse("1945.08.17"));
            Book book3 = new Book(1, 2, 5490, "Homage to Catalonia", "Autobiographical", "9780156421171", DateTime.Parse("1938.04.25"));
            Book book4 = new Book(2, 2, 2990, "Brave New World", "Science Fiction", "9780060850524", DateTime.Parse("1932.10.27"));
            Book book5 = new Book(2, 1, 3790, "The Doors of Perception", "Philosophical", "9780060850525", DateTime.Parse("1954.05.04"));
            Book book6 = new Book(2, 2, 4490, "Island", "Utopian Fiction", "9780061434493", DateTime.Parse("1962.11.06"));
            Book book7 = new Book(3, 3, 1990, "Toldi", "Epic Poem", "9789635544048", DateTime.Parse("1846.01.01"));
            Book book8 = new Book(3, 3, 2290, "A walesi bárdok", "Epic Poem", "9789635544536", DateTime.Parse("1857.01.01"));
            Book book9 = new Book(3, 3, 1790, "Arany János összes költeményei", "Poetry Collection", "9789635544505", DateTime.Parse("1879.01.01"));
            Book book10 = new Book(4, 1, 2490, "Egri csillagok", "Historical Novel", "9789639683107", DateTime.Parse("1899.01.01"));
            Book book11 = new Book(4, 1, 1990, "Lámpás", "Novel", "9789638163394", DateTime.Parse("1901.01.01"));
            Book book12 = new Book(4, 2, 2290, "A láthatatlan ember", "Novel", "9789635546073", DateTime.Parse("1930.01.01"));
            Book book13 = new Book(5, 1, 1990, "The Choice: Embrace the Possible", "Biography", "9781501130786", DateTime.Parse("2017.09.05"));
            Book book14 = new Book(5, 1, 2490, "The Gift: 12 Lessons to Save Your Life", "Self.Help", "9781984800406", DateTime.Parse("2020.09.15"));




            modelBuilder.Entity<Publisher>().HasData(libri, akademiai, corvina);
            modelBuilder.Entity<Author>().HasData(author1, author2, author3, author4, author5);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14);



        }

    }
}