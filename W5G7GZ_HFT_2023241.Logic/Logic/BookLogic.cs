using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;
using W5G7GZ_HFT_2023241.Repository.Repositories;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class BookLogic : IBookLogic
    {
        IAuthorRepository AuthorRepo;
        IBookRepository BookRepo;

        public BookLogic(IBookRepository BookRepo, IAuthorRepository AuthorRepo)
        {
            this.AuthorRepo = AuthorRepo;
            this.BookRepo = BookRepo;
        }

        //crud
        public void Create(Book item)
        {
            if (item.Title.Length < 1)
            {
                throw new ArgumentException("Book name is too short...");
            }
            if (item.Price < 0)
            {
                throw new ArgumentException("Book price can't be negative");
            }
            this.BookRepo.Create(item);
        }
        public Book Read(int id)
        {
            var book = this.BookRepo.Read(id);

            if (book == null || id < 0)
            {
                throw new InvalidOperationException($"Id is not valid");
            }

            return book;
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
                .Where(b => b.Publisher != null)
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
            var result = (from x in BookRepo.ReadAll()
                          group x by x.Author.AuthorName into grouped
                          orderby grouped.Count()
                          select new KeyValuePair<string, int>(grouped.Key, grouped.Count())).Take(1);


            return authorWithMostBooks;
        }

        public int PriceOfAllBooks()
        {
            var Prices = from x in BookRepo.ReadAll()
                         group x by x.BookID into g
                         select g.Sum(x => x.Price);
            return Prices.Sum();
        }

        public List<Author> AuthorsBornInDecade(int startYear)
        {
            var authors = AuthorRepo.ReadAll().Where(a => a.BirthYear >= startYear && a.BirthYear <= startYear + 10).ToList();
            return authors;
        }
        public IEnumerable<string> AuthorsWithMultipleBooks()
        {
            var authorsWithMultipleBooks = BookRepo.ReadAll()
                .GroupBy(b => b.Author.AuthorName)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);

            return authorsWithMultipleBooks;
        }

        public List<Book> BooksByGenre(string genre)
        {
            var books = BookRepo.ReadAll().Where(b => b.Genre == genre).ToList();
            return books;
        }
    }
}