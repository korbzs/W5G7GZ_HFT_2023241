using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class BookLogic : IBookLogic
    {
        IRepository<Author> AuthorRepo;
        IRepository<Book> BookRepo;
        IRepository<Publisher> PublisherRepo;

        public BookLogic(IRepository<Book> BookRepo, IRepository<Author> AuthorRepo, IRepository<Publisher> PublisherRepo)
        {
            this.AuthorRepo = AuthorRepo;
            this.BookRepo = BookRepo;
            this.PublisherRepo = PublisherRepo;
        }

        //crud
        public void Create(Book item)
        {
            if (item.Title.Length < 1)
            {
                throw new ArgumentException("Book name is too short...");
            }
            this.BookRepo.Create(item);
        }
        public Book Read(int id)
        {
            return this.BookRepo.Read(id);
        }
        public void Update(Book item)
        {
            this.BookRepo.Update(item);
        }

        public void Delete(int id)
        {
            this.BookRepo.Delete(id);
        }

        public IQueryable<Book> ReadAll()
        {
            return this.BookRepo.ReadAll();
        }
        //non-crud
        public IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher()
        {
            var bookCounts = BookRepo.ReadAll()
        .GroupBy(b => b.Publisher.PublisherName)
        .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()));

            return bookCounts;
        }

        public KeyValuePair<string, int> AuthorWithTheMostBooks()
        {
            var authorWithMostBooks = BookRepo.ReadAll()
                .GroupBy(b => b.Author.AuthorName)
                .Select(group => new KeyValuePair<string, int>(group.Key, group.Count()))
                .OrderByDescending(pair => pair.Value)
                .FirstOrDefault();

            return authorWithMostBooks;
        }

        public int PriceOfAllBooks()
        {
            var Prices = from x in BookRepo.ReadAll()
                        group x by x.BookID into g
                        select g.Sum(x => x.Price);
            int Total = 0;
            foreach(var item in Prices)
            {
                Total += item;
            }
            return Total;
        }
        public IEnumerable<string> AuthorsWithMultipleBooks()
        {
            var authorsWithMultipleBooks = BookRepo.ReadAll()
                .GroupBy(b => b.Author.AuthorName)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);

            return authorsWithMultipleBooks;
        }
        public IEnumerable<dynamic> GenresForAuthors()
        {
            var genresForAuthors = from author in AuthorRepo.ReadAll()
                                   join book in BookRepo.ReadAll() on author.AuthorID equals book.Author.AuthorID
                                   group book.Genre by author.AuthorName into genreGroup
                                   select new { AuthorName = genreGroup.Key, Genres = genreGroup.ToList() };

            return genresForAuthors;
        }
    }
}