using System.Collections.Generic;
using W5G7GZ_HFT_2023241.Logic.Logic;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace W5G7GZ_HFT_2023241.Test
{
    public class Teszt
    {
        [TestFixture]
        public class BookLogicTests
        {
            private BookLogic bookLogic { get; set; }

            [SetUp]
            public void Setup()
            {
                Mock<IRepository<Author>> mockedAuthorRepo = new Mock<IRepository<Author>>();
                Mock<IRepository<Book>> mockedBookRepo = new Mock<IRepository<Book>>();
                Mock<IRepository<Publisher>> mockedPublisherRepo = new Mock<IRepository<Publisher>>();

                mockedAuthorRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                    new Author()
                    {
                        AuthorID = 12,
                        AuthorName = "Mikszáth Kálmán",
                        BirthYear = 1847,
                        Nationality = "Hungarian"

                    });

                mockedBookRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                    new Book()
                    {
                        BookID = 12,
                        AuthorID = 12,
                        Title = "Szent Péter esernyője",
                        Genre = "fiction",
                        PublicationYear = 1895
                    });

                mockedPublisherRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                    new Publisher()
                    {
                        PublisherID = 100,
                        PublisherName = "Corvinus"
                    });


                mockedAuthorRepo.Setup(x => x.ReadAll()).Returns(this.FakeAuthorObjects);
                mockedBookRepo.Setup(x => x.ReadAll()).Returns(this.FakeBookObjects);
                mockedPublisherRepo.Setup(x => x.ReadAll()).Returns(this.FakePublisherObjects);

                this.bookLogic = new BookLogic(mockedBookRepo.Object, mockedAuthorRepo.Object, mockedPublisherRepo.Object);
            }

            [Test]
            public void CreateValidBookShouldAddBook()
            {
                var validBook = new Book(11, 2, 2890, "Sorstalanság", "drama", "9789631424645", 1975);
                Assert.That(() => this.bookLogic.Create(validBook), Throws.Nothing);
            }

            [Test]
            public void CreateInvalidTitleShouldThrowArgumentException()
            {
                var invalidBook = new Book(12, 2, 2890, "", "comedy", "1234567890", 1999);
                Assert.That(() => this.bookLogic.Create(invalidBook), Throws.TypeOf<ArgumentException>());
            }

            [Test]
            public void CreateInvalidPriceShouldThrowArgumentException()
            {
                var invalidBook = new Book(13, 2, -100, "Invalid Book", "Test Genre", "1234567890", 1876);
                Assert.That(() => this.bookLogic.Create(invalidBook), Throws.TypeOf<ArgumentException>());
            }

            [Test]
            public void ReadValidIdShouldReturnBook()
            {
                var book = this.bookLogic.Read(12);
                Assert.That(book.Title, Is.EqualTo("Szent Péter esernyője"));
            }

            [Test]
            public void ReadInvalidIdShouldThrowInvalidOperationException()
            {
                Assert.That(() => this.bookLogic.Read(-1), Throws.TypeOf<InvalidOperationException>());
            }


            [Test]
            public void BookCountPerPublisherShouldReturnCorrectCounts()
            {
                var result = this.bookLogic.BookCountPerPublisher();

                Assert.That(result, Is.Not.Null, "Result should not be null");
                Assert.That(result, Is.Not.Empty, "Result should not be empty");

                // Check if the result contains the expected counts
                Assert.That(result, Is.EquivalentTo(
                    new[]
                {
                new KeyValuePair<string, int>("Luther Kiadó", 1),
                new KeyValuePair<string, int>("Kalligram", 1),
                new KeyValuePair<string, int>("Helikon", 1),
            }));
            }
            

            private IQueryable<Author> FakeAuthorObjects()
            {
                Author author1 = new Author() { AuthorID = 1, AuthorName = "Márai Sándor", BirthYear = 1900, Nationality = "Hungarian" };
                Author author2 = new Author() { AuthorID = 2, AuthorName = "Szabó Magda", BirthYear = 1917, Nationality = "Hungarian" };
                Author author3 = new Author() { AuthorID = 3, AuthorName = "Esterházy Péter", BirthYear = 1950, Nationality = "Hungarian" };

                List<Author> authors = new List<Author>
                {
                    author1,
                    author2,
                    author3
                };

                return authors.AsQueryable();

            }

            private IQueryable<Book> FakeBookObjects()
            {
                Author author1 = new Author() { AuthorID = 1, AuthorName = "Márai Sándor", BirthYear = 1900, Nationality = "Hungarian" };
                Author author2 = new Author() { AuthorID = 2, AuthorName = "Szabó Magda", BirthYear = 1917, Nationality = "Hungarian" };
                Author author3 = new Author() { AuthorID = 3, AuthorName = "Esterházy Péter", BirthYear = 1950, Nationality = "Hungarian" };
                Author author4 = new Author() { AuthorID = 4, AuthorName = "Jókai Mór", BirthYear = 1950, Nationality = "Hungarian" };
                Author author5 = new Author() { AuthorID = 4, AuthorName = "Gipsz Jakab", BirthYear = 2010, Nationality = "Hungarian" };

                Publisher publisher1 = new Publisher() { PublisherID = 1, PublisherName = "Luther Kiadó", Headquarters = "Budapest", FoundatitonYear = 1945 };
                Publisher publisher2 = new Publisher() { PublisherID = 2, PublisherName = "Kalligram", Headquarters = "Bratislava", FoundatitonYear = 1992 };
                Publisher publisher3 = new Publisher() { PublisherID = 3, PublisherName = "Helikon", Headquarters = "Budapest", FoundatitonYear = 1949 };
                //Publisher publisher4 = new Publisher() { PublisherID = 3, PublisherName = "Nevesincs Kiadó", Headquarters = "Budapest", FoundatitonYear = 2023 };

                Book book1 = new Book() { BookID = 1, AuthorID = author1.AuthorID, PublisherID = publisher1.PublisherID, Price = 5000, Title = "Embers", Genre = "Novel", ISBN = "9789631440504", PublicationYear = 1942 };
                Book book2 = new Book() { BookID = 2, AuthorID = author2.AuthorID, PublisherID = publisher2.PublisherID, Price = 4500, Title = "Az ajtó", Genre = "Novel", ISBN = "9780062314404", PublicationYear = 1987 };
                Book book3 = new Book() { BookID = 3, AuthorID = author3.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Celestial Harmonies", Genre = "Novel", ISBN = "9781400078748", PublicationYear = 2000 };
                Book book4 = new Book() { BookID = 4, AuthorID = author2.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Abigél", Genre = "Historic novel", ISBN = "9789634158493", PublicationYear = 1970 };



                List<Book> books = new List<Book>
                {
                    book1,
                    book2,
                    book3
                };

                return books.AsQueryable();
            }
            private IQueryable<Publisher> FakePublisherObjects()
            {
                Publisher publisher1 = new Publisher() { PublisherID = 1, PublisherName = "Magveto", Headquarters = "Budapest", FoundatitonYear = 1945 };
                Publisher publisher2 = new Publisher() { PublisherID = 2, PublisherName = "Kalligram", Headquarters = "Bratislava", FoundatitonYear = 1992 };
                Publisher publisher3 = new Publisher() { PublisherID = 3, PublisherName = "Helikon", Headquarters = "Budapest", FoundatitonYear = 1949 };

                List<Publisher> publishers = new List<Publisher>
                {
                    publisher1,
                    publisher2,
                    publisher3
                };

                return publishers.AsQueryable();
            }

        }
    }
}
