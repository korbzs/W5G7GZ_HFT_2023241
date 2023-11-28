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
        .HasKey(b => b.BookID);

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

            Author author1 = new Author(1, "George Orwell", 1903, "British");
            Author author2 = new Author(2, "Aldous Huxley", 1894, "British");
            Author author3 = new Author(3, "Arany János", 1817, "Hungarian");
            Author author4 = new Author(4, "Gárdonyi Géza", 1863, "Hungarian");
            Author author5 = new Author(5, "Edith Eva Eger", 1927, "Hungarian");
            Author author6 = new Author(5, "Alpár Aladár", 2001, "Hungarian");


            Book book1 = new Book(1, 1, 1, 4990, "1984", "Dystopic Fiction", "9780451524935", 1949);
            Book book1_ = new Book(2, 1, 1, 4290, "1984", "Dystopic Fiction", "9780451524935", 1949);
            Book book2 = new Book(3, 1, 2, 3990, "Animal Farm", "Allegorical Novella", "9780451524936", 1945);
            Book book3 = new Book(4, 1, 2, 5490, "Homage to Catalonia", "Autobiographical", "9780156421171", 1938);
            Book book4 = new Book(5, 2, 2, 2990, "Brave New World", "Science Fiction", "9780060850524", 1932);
            Book book5 = new Book(6, 2, 2, 3790, "The Doors of Perception", "Philosophical", "9780060850525", 1954);
            Book book6 = new Book(7, 2, 2, 4490, "Island", "Utopian Fiction", "9780061434493", 1962);
            Book book7 = new Book(8, 3, 3, 1990, "Toldi", "Epic Poem", "9789635544048", 1846);
            Book book8 = new Book(9, 3, 3, 2290, "A walesi bárdok", "Epic Poem", "9789635544536", 1857);
            Book book9 = new Book(10, 3, 3, 1790, "Arany János összes költeményei", "Poetry Collection", "9789635544505", 1879);
            Book book10 = new Book(11, 4, 4, 2490, "Egri csillagok", "Historical Novel", "9789639683107", 1899);
            Book book11 = new Book(12, 4, 4, 1990, "Lámpás", "Novel", "9789638163394", 1901);
            Book book12 = new Book(13, 4, 4, 2290, "A láthatatlan ember", "Novel", "9789635546073", 1930);
            Book book13 = new Book(14, 5, 5, 1990, "The Choice: Embrace the Possible", "Biography", "9781501130786", 2017);
            Book book14 = new Book(15, 5, 5, 2490, "The Gift: 12 Lessons to Save Your Life", "Self.Help", "9781984800406", 2020);




            modelBuilder.Entity<Publisher>().HasData(libri, akademiai, corvina);
            modelBuilder.Entity<Author>().HasData(author1, author2, author3, author4, author5);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4, book5, book6, book7, book8, book9, book10, book11, book12, book13, book14);



        }

    }
}