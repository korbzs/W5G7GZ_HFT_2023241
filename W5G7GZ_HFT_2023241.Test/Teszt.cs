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
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Test
{
    public class Teszt
    {
        [TestFixture]
        public class BookLogicTests
        {
            private AuthorLogic authorLogic { get; set; }
            private BookLogic bookLogic { get; set; }
            private PublisherLogic publisherLogic { get; set; }

            [SetUp]
            public void Setup()
            {
                Mock<IAuthorRepository> mockedAuthorRepo = new Mock<IAuthorRepository>();
                Mock<IBookRepository> mockedBookRepo = new Mock<IBookRepository>();
                Mock<IPublisherRepository> mockedPublisherRepo = new Mock<IPublisherRepository>();

                //I don't use that just in case
                #region SetupOfRead
                //mockedAuthorRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                //    new Author()
                //    {
                //        AuthorID = 12,
                //        AuthorName = "Mikszáth Kálmán",
                //        BirthYear = 1847,
                //        Nationality = "Hungarian",

                //        Books = new Book[]
                //        {
                //            new Book() { BookID = 1, AuthorID = 1, PublisherID = 1, Price = 5000, Title = "A jó palócok", Genre = "Novel", ISBN = "9789631440534", PublicationYear = 1882 },
                //            new Book() { BookID = 2, AuthorID = 1, PublisherID = 2, Price = 5500, Title = "Tót atyafiak", Genre = "Novel/Realism", ISBN = "9439631440534", PublicationYear = 1881 },
                //            new Book() { BookID = 3, AuthorID = 1, PublisherID = 1, Price = 3500, Title = "Szent Péter esernyője", Genre = "Novel", ISBN = "9789631440534", PublicationYear = 1882 },
                //        }
                //    });

                //mockedBookRepo.Setup(x => x.Read(It.IsAny<int>())).Returns( //It.IsAny<int>()
                //    new Book() // booklist ->sok book
                //    {
                //        BookID = 12,
                //        AuthorID = 12,
                //        Title = "Szent Péter esernyője",
                //        Genre = "fiction",
                //        PublicationYear = 1895,

                //        Publisher = new Publisher(100, "AKiadó", "Budapest", 2000),
                //        Author = new Author(12, "Mikszáth Kálmán", 1847, "Hungarian")

                //    });

                //mockedPublisherRepo.Setup(x => x.Read(It.IsAny<int>())).Returns(
                //    new Publisher()
                //    {
                //        PublisherID = 100,
                //        PublisherName = "Corvinus"
                //    });

                #endregion // 

                #region authorList
                Author author1 = new Author() { AuthorID = 1, AuthorName = "Márai Sándor", BirthYear = 1900, Nationality = "Hungarian" };
                Author author2 = new Author() { AuthorID = 2, AuthorName = "Szabó Magda", BirthYear = 1917, Nationality = "Hungarian" };
                Author author3 = new Author() { AuthorID = 3, AuthorName = "Esterházy Péter", BirthYear = 1950, Nationality = "Hungarian" };

                List<Author> authorList = new List<Author>
                {
                    author1,
                    author2,
                    author3
                };
                #endregion

                #region bookList
                Author author10 = new Author() { AuthorID = 1, AuthorName = "Márai Sándor", BirthYear = 1900, Nationality = "Hungarian" };
                Author author20 = new Author() { AuthorID = 2, AuthorName = "Szabó Magda", BirthYear = 1917, Nationality = "Hungarian" };
                Author author30 = new Author() { AuthorID = 3, AuthorName = "Esterházy Péter", BirthYear = 1950, Nationality = "Hungarian" };
                Author author40 = new Author() { AuthorID = 4, AuthorName = "Jókai Mór", BirthYear = 1950, Nationality = "Hungarian" };
                Author author50 = new Author() { AuthorID = 4, AuthorName = "Gipsz Jakab", BirthYear = 2010, Nationality = "Hungarian" };

                Publisher publisher1 = new Publisher() { PublisherID = 1, PublisherName = "Luther Kiadó", Headquarters = "Budapest", FoundatitonYear = 1945 };
                Publisher publisher2 = new Publisher() { PublisherID = 2, PublisherName = "Kalligram", Headquarters = "Bratislava", FoundatitonYear = 1992 };
                Publisher publisher3 = new Publisher() { PublisherID = 3, PublisherName = "Helikon", Headquarters = "Budapest", FoundatitonYear = 1949 };
                //Publisher publisher4 = new Publisher() { PublisherID = 3, PublisherName = "Nevesincs Kiadó", Headquarters = "Budapest", FoundatitonYear = 2023 };

                Book book1 = new Book() { BookID = 1, AuthorID = author1.AuthorID, PublisherID = publisher1.PublisherID, Price = 5000, Title = "Embers", Genre = "Novel", ISBN = "9789631440504", PublicationYear = 1942, Author = author1, Publisher = publisher1 };
                Book book2 = new Book() { BookID = 2, AuthorID = author2.AuthorID, PublisherID = publisher2.PublisherID, Price = 4500, Title = "Az ajtó", Genre = "Novel", ISBN = "9780062314404", PublicationYear = 1987, Author = author2, Publisher = publisher2 };
                Book book3 = new Book() { BookID = 3, AuthorID = author3.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Celestial Harmonies", Genre = "Novel", ISBN = "9781400078748", PublicationYear = 2000, Author = author3, Publisher = publisher3 };
                Book book4 = new Book() { BookID = 4, AuthorID = author2.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Abigél", Genre = "Historic novel", ISBN = "9789634158493", PublicationYear = 1970, Author = author2, Publisher = publisher3 };


                List<Book> bookList = new List<Book>
                {
                    book1,
                    book2,
                    book3,
                    book4
                };
                #endregion

                #region publisherList
                Publisher publisher10 = new Publisher() { PublisherID = 1, PublisherName = "Magveto", Headquarters = "Budapest", FoundatitonYear = 1945 };
                Publisher publisher20 = new Publisher() { PublisherID = 2, PublisherName = "Kalligram", Headquarters = "Bratislava", FoundatitonYear = 1992 };
                Publisher publisher30 = new Publisher() { PublisherID = 3, PublisherName = "Helikon", Headquarters = "Budapest", FoundatitonYear = 1949 };

                List<Publisher> publisherList = new List<Publisher>
                {
                    publisher1,
                    publisher2,
                    publisher3
                };

                #endregion

                bookList.ForEach(book => { book.Author = authorList.Find(x => 
                                    x.AuthorID == book.AuthorID); 
                });

                bookList.ForEach(book => {
                                    book.Publisher = publisherList.Find(x =>
                                    x.PublisherID == book.PublisherID);
                });

                #region SetupOfReposAndLogics
                mockedAuthorRepo.Setup(x => x.ReadAll()).Returns(this.FakeAuthorObjects);
                mockedBookRepo.Setup(x => x.ReadAll()).Returns(this.FakeBookObjects);
                mockedPublisherRepo.Setup(x => x.ReadAll()).Returns(this.FakePublisherObjects);


                this.bookLogic = new BookLogic(mockedBookRepo.Object, mockedAuthorRepo.Object);
                this.authorLogic = new AuthorLogic(mockedAuthorRepo.Object);
                this.publisherLogic = new PublisherLogic(mockedPublisherRepo.Object);
                #endregion
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
                var book = this.bookLogic.Read(1); // 4:Abigél || 12:Szent Péter esernyője
                Assert.That(book.Title, Is.EqualTo("Embers"));
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

                Assert.That(result, Is.EquivalentTo(
                    new[]
                {
                new KeyValuePair<string, int>("Luther Kiadó", 1),
                new KeyValuePair<string, int>("Kalligram", 1),
                new KeyValuePair<string, int>("Helikon", 2),
            }));
            }

            #region visol
            public IQueryable<Author> FakeAuthorObjects()
            {
                Author author1 = new Author() { AuthorID = 1, AuthorName = "Márai Sándor", BirthYear = 1900, Nationality = "Hungarian" };
                Author author2 = new Author() { AuthorID = 2, AuthorName = "Szabó Magda", BirthYear = 1917, Nationality = "Hungarian" };
                Author author3 = new Author() { AuthorID = 3, AuthorName = "Esterházy Péter", BirthYear = 1950, Nationality = "Hungarian" };

                List<Author> authorList = new List<Author>
                {
                    author1,
                    author2,
                    author3
                };

                return authorList.AsQueryable();

            }

            public IQueryable<Book> FakeBookObjects()
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

                Book book1 = new Book() { BookID = 1, AuthorID = author1.AuthorID, PublisherID = publisher1.PublisherID, Price = 5000, Title = "Embers", Genre = "Novel", ISBN = "9789631440504", PublicationYear = 1942, Author = author1, Publisher = publisher1 };
                Book book2 = new Book() { BookID = 2, AuthorID = author2.AuthorID, PublisherID = publisher2.PublisherID, Price = 4500, Title = "Az ajtó", Genre = "Novel", ISBN = "9780062314404", PublicationYear = 1987, Author = author2, Publisher = publisher2 };
                Book book3 = new Book() { BookID = 3, AuthorID = author3.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Celestial Harmonies", Genre = "Novel", ISBN = "9781400078748", PublicationYear = 2000, Author = author3, Publisher = publisher3 };
                Book book4 = new Book() { BookID = 4, AuthorID = author2.AuthorID, PublisherID = publisher3.PublisherID, Price = 5500, Title = "Abigél", Genre = "Historic novel", ISBN = "9789634158493", PublicationYear = 1970, Author = author2, Publisher = publisher3 };


                List<Book> bookList = new List<Book>
                {
                    book1,
                    book2,
                    book3,
                    book4
                };

                return bookList.AsQueryable();
            }
            public IQueryable<Publisher> FakePublisherObjects()
            {
                Publisher publisher1 = new Publisher() { PublisherID = 1, PublisherName = "Magveto", Headquarters = "Budapest", FoundatitonYear = 1945 };
                Publisher publisher2 = new Publisher() { PublisherID = 2, PublisherName = "Kalligram", Headquarters = "Bratislava", FoundatitonYear = 1992 };
                Publisher publisher3 = new Publisher() { PublisherID = 3, PublisherName = "Helikon", Headquarters = "Budapest", FoundatitonYear = 1949 };

                List<Publisher> publisherList = new List<Publisher>
                {
                    publisher1,
                    publisher2,
                    publisher3
                };

                return publisherList.AsQueryable();
            }
            #endregion


        }
    }
}
