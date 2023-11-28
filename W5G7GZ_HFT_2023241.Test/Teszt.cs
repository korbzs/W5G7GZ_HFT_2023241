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
            private BookLogic bookLogic;

            [SetUp]
            public void Setup()
            {
                Mock<IRepository<Book>> mockedBookRepo = new Mock<IRepository<Book>>();
                Mock<IRepository<Author>> mockedAuthorRepo = new Mock<IRepository<Author>>();
                Mock<IRepository<Publisher>> mockedPublisherRepo = new Mock<IRepository<Publisher>>();

                mockedBookRepo.Setup(x => x.ReadAll()).Returns(FakeBookObjects().AsQueryable());
                mockedAuthorRepo.Setup(x => x.ReadAll()).Returns(FakeAuthorObjects().AsQueryable());
                mockedPublisherRepo.Setup(x => x.ReadAll()).Returns(FakePublisherObjects().AsQueryable());

                this.bookLogic = new BookLogic(mockedBookRepo.Object, mockedAuthorRepo.Object, mockedPublisherRepo.Object);
            }

            [Test]
            public void Create_WithValidBook_ShouldAddBook()
            {
                var newBook = new Book(11, 2, 2890, "Test Book", "Test Genre", "1234567890", DateTime.Now);
                Assert.That(() => this.bookLogic.Create(newBook), Throws.Nothing);
            }

            [Test]
            public void Create_WithShortTitle_ShouldThrowArgumentException()
            {
                var invalidBook = new Book(12, 2, 2890, "", "Test Genre", "1234567890", DateTime.Now);
                Assert.That(() => this.bookLogic.Create(invalidBook), Throws.TypeOf<ArgumentException>());
            }

            [Test]
            public void Create_WithNegativePrice_ShouldThrowArgumentException()
            {
                var invalidBook = new Book(13, 2, -100, "Invalid Book", "Test Genre", "1234567890", DateTime.Now);
                Assert.That(() => this.bookLogic.Create(invalidBook), Throws.TypeOf<ArgumentException>());
            }

            [Test]
            public void Read_WithValidId_ShouldReturnBook()
            {
                var book = this.bookLogic.Read(4);
                Assert.That(book.Title, Is.EqualTo("Fahrenheit 451"));
            }

            [Test]
            public void Read_WithInvalidId_ShouldThrowInvalidOperationException()
            {
                Assert.That(() => this.bookLogic.Read(999), Throws.TypeOf<InvalidOperationException>());
            }

            // Add similar tests for other methods...

            private List<Book> FakeBookObjects()
            {
                // Define your fake book objects here...
            }

            private List<Author> FakeAuthorObjects()
            {
                // Define your fake author objects here...
            }

            private List<Publisher> FakePublisherObjects()
            {
                // Define your fake publisher objects here...
            }
        }
    }
}
